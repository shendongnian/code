    public float sensX = 100.0f;
	float rotationX = 0.0f;
 
	void Update () {
 
		if (Input.GetMouseButton (0)) {
			rotationX += Input.GetAxis ("Mouse X") * sensX * Time.deltaTime;
			transform.localEulerAngles = new Vector3 (0, rotationX, 0);
		}
	}
