	void Update () 
	{
		if(Input.GetKey(KeyCode.LeftArrow))
		{
			transform.Translate(-Vector3.right * Time.deltaTime);
		}
		else if(Input.GetKey(KeyCode.RightArrow))
		{
			transform.Translate(Vector3.right * Time.deltaTime);
		}
	}
