    public float rotSpeed;
    public float playerSpeed;
        void Update()
        {
            if (Input.GetKey(KeyCode.RightArrow))
            {
                transform.Rotate( Vector3.up,  Time.deltaTime * rotSpeed);
            } else if (Input.GetKey(KeyCode.LeftArrow))
            {
                transform.Rotate(-Vector3.up, Time.deltaTime * rotSpeed);
            }
            if (Input.GetKey(KeyCode.UpArrow))
            {
                transform.Translate(Vector3.forward * Time.deltaTime * playerSpeed);
            } else if (Input.GetKey(KeyCode.DownArrow))
            {
                transform.Translate(-Vector3.forward * Time.deltaTime * playerSpeed);
            }
        }
