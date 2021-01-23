	float constantspeed = 3;
	float speed;
	//Key inputs
	void Update () {
		transform.Translate (constantspeed * Time.deltaTime, 0, 0);
		if (Input.GetKeyDown (KeyCode.D)) {	 
			StopAllCoroutines ();
			StartCoroutine (RightMovement(0f));
		}
		if (Input.GetKeyDown (KeyCode.A)) {
			StopAllCoroutines ();
			StartCoroutine (LeftMovement(0f));
		}
	}
	//Movement itself (Right, Left)
	IEnumerator RightMovement (float Rloop) {
		
		while (transform.position.x < Time.time * constantspeed + 6) {
			
			speed = 10f;
			transform.Translate (speed * Time.deltaTime, 0, 0);
			yield return new WaitForSeconds (Rloop);
		}
		if (transform.position.x > Time.time * constantspeed + 5.9) {
			
			StopAllCoroutines ();
			StartCoroutine (LeftMovement (0f));
		}
	}
	IEnumerator LeftMovement (float Lloop) {
		while (transform.position.x > Time.time * constantspeed -8) {
			
			speed = -7f;
			transform.Translate (speed * Time.deltaTime, 0, 0);
			yield return new WaitForSeconds (Lloop);
		}
	}
}
