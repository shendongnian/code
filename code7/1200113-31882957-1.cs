	public GameObject ForCube;
	public float RotateTime = 5;
	public float Timer = 0;
	public float PauseTime = 0;
	private bool Pause = false;
	private bool Rotate = true;
	
	// Use this for initializat
	void Start ()
	{
		Timer = RotateTime;
		PauseTime = RotateTime;
		ForCube = GameObject.Find ("Cube");
		Debug.Log (ForCube);
	}
	
	// Update is called once per frame
	void Update ()
	{
		//Start Rotating When Press Space Key
		if (Rotate)
			Pause = false;
		else if (!Rotate) {
			Pause = true;
		}
		if (!Pause)
			RotateForSec (ref Timer);
			else RotatePause ();
			
	}
	//Function to pause PauseTime sec
	void RotatePause()
	{
		if (PauseTime > 0) {
			PauseTime -= Time.deltaTime;
		} else {
			Pause = false;
			Rotate = true;
			PauseTime = RotateTime;
		}
	}
	//Function to Rotate for X sec
	void RotateForSec(ref float sec)
	{
		if (Rotate && sec > 0) {
			Debug.Log (Time.time);
			ForCube.transform.Rotate (10, 10, 10);
			sec -= Time.deltaTime;
		} else Rotate = false;
		//Reset Rotating Time after rotating 
		if (!Rotate && sec <= 0) Timer = RotateTime;
	}
    }
