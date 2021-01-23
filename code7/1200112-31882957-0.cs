    using UnityEngine;
    using System.Collections;
    public class Ruch : MonoBehaviour
    {
	public GameObject ForCube;
	public float RotateTime = 5;
	public float Timer = 0;
	private bool Rotate = false;
	
	// Use this for initializat
	void Start ()
	{
		Timer = RotateTime;
		ForCube = GameObject.Find ("Cube");
		Debug.Log (ForCube);
	}
	
	// Update is called once per frame
	void Update ()
	{
		//Start Rotating When Press Space Key
		if (Input.GetKeyDown (KeyCode.Space)) Rotate = true;
		else if (!(Input.GetKeyDown (KeyCode.Space))&&Timer <=0) Rotate = false;
		RotateForSec (ref Timer);
	}
	//Function to Rotate for X sec
	void RotateForSec(ref float sec)
	{
		if (Rotate && sec > 0) {
			Debug.Log (Time.time);
			ForCube.transform.Rotate (10, 10, 10);
			sec -= Time.deltaTime;
		} 
		//Reset Rotating Time after rotating 
		if (!Rotate && sec <= 0) Timer = RotateTime;
	}
    }
