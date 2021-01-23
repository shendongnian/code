    public Vector3 playerPosR;
    public float paddleSpeed = 1F;
    public float yClamp;
    // Update is alled once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.UpArrow))
        {
            float yPos = transform.position.y + (Input.GetAxis("Vertical") * paddleSpeed);
            playerPosR = new Vector3(transform.position.x, Mathf.Clamp(yPos, -yClamp, yClamp), 0);
            transform.position = playerPosR;
        }
    }
