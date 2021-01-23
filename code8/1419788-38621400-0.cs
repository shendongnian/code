    public GameObject Knife;  //  knife 3d model
	public bool isKnifeActive;  // bool to check knife is there in hand or not
	void Start()
	{
		Knife.SetActive (false);
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetKeyDown (KeyCode.Space))
		{
			Knife.SetActive = true;
			isKnifeActive = true;
			StartCoroutine ("Knifedisable");
		}
		if (Input.GetMouseButtonDown (0)) 
		{
			playerAttack ();
		}
	}
	public void playerAttack()
	{
		if (isKnifeActive) 
		{
			//********** play your knife - player attacking animation here ***************//
		}
	}
	IEnumerator Knifedisable()
	{
		yield return new WaitForSeconds (5);
		Knife.SetActive = false;
		isKnifeActive = false;
	}
	void OnTriggerEnter()
	{
		//********* write your opponent health reducing code here *************//
	}
