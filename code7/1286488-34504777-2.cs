	// Use this for initialization
	void Start () {
		gameObject.GetComponent<ParticleSystem>().enableEmission = false;
		gameObject.GetComponent<ParticleSystem>().Stop();
	}
	
	// Update is called once per frame
	void Update () {
		//gameObject.GetComponent<ParticleSystem>().enableEmission = false;
		//gameObject.GetComponent<ParticleSystem>().Stop();
	}
