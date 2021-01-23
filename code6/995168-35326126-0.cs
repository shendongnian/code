        public float playerSpeed;  //allows us to be able to change speed in Unity
    public Vector2 jumpHeight;
	// Use this for initialization
	void Start () {
	
	}
    // Update is called once per frame
    void Update ()
    {
        transform.Translate(playerSpeed * Time.deltaTime, 0f, 0f);  //makes player run
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))  //makes player jump
        {
            GetComponent<Rigidbody2D>().AddForce(jumpHeight, ForceMode2D.Impulse);
