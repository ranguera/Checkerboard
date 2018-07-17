using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Checker : MonoBehaviour {

    public Text ITIText;
    public Text stimulusText;
    public Text freqText;
    public GameObject checkerboard;

    private float ITI;
    private float lastSpawn;
    private float stimulusTime;
    private Material mat;
    private Vector4 matFreq;

	// Use this for initialization
	void Start () {
        ITI = 5f;
        stimulusTime = .1f;
        lastSpawn = 0f;
        mat = checkerboard.GetComponent<Renderer>().material;
        matFreq = mat.GetVector("Vector2_8D7263AF");
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(Input.GetKey(KeyCode.UpArrow))
        {
            ITI += .02f;
            ITIText.text = "(Up/Down) ITI: " + ITI;
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            ITI -= .02f;
            ITIText.text = "(Up/Down) ITI: " + ITI;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            stimulusTime += .002f;
            stimulusText.text = "(Left/Right) Stimulus: " + stimulusTime;
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            stimulusTime -= .002f;
            stimulusText.text = "(Left/Right) Stimulus: " + stimulusTime;
        }
        else if (Input.GetKeyDown(KeyCode.Q))
        {
            matFreq.x += 1;
            mat.SetVector("Vector2_8D7263AF", matFreq);
            freqText.text = "(A/Q, S/W) Freq: " + matFreq.x + "," + matFreq.y;
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            matFreq.x -= 1;
            mat.SetVector("Vector2_8D7263AF", matFreq);
            freqText.text = "(A/Q, S/W) Freq: " + matFreq.x + "," + matFreq.y;
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            matFreq.y += 1;
            mat.SetVector("Vector2_8D7263AF", matFreq);
            freqText.text = "(A/Q, S/W) Freq: " + matFreq.x + "," + matFreq.y;
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            matFreq.y -= 1;
            mat.SetVector("Vector2_8D7263AF", matFreq);
            freqText.text = "(A/Q, S/W) Freq: " + matFreq.x + "," + matFreq.y;
        }

        if(Time.time > lastSpawn+ITI)
        {
            checkerboard.SetActive(true);
            lastSpawn = Time.time;
        }

        if( checkerboard.activeSelf)
        {
            StartCoroutine(Hide());
        }
	}

    private IEnumerator Hide()
    {
        yield return new WaitForSeconds(stimulusTime);
        checkerboard.SetActive(false);
    }
}
