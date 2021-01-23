       Vector2 dir;
        public float snakeSpeed = 0.06f; //To control the speed of the snake
        int frame = 0;
    
        void Start()
        {
            dir = Vector2.right * snakeSpeed;
        }
    
    
        // Update is called once per frame
        void Update()
        {
            frame += 1;
            // Move in a new Direction?
            if (Input.GetKey(KeyCode.RightArrow))
                dir = Vector2.right * snakeSpeed;
            else if (Input.GetKey(KeyCode.DownArrow))
                dir = -Vector2.up * snakeSpeed;    // '-up' means 'down'
            else if (Input.GetKey(KeyCode.LeftArrow))
                dir = -Vector2.right * snakeSpeed; // '-right' means 'left'
            else if (Input.GetKey(KeyCode.UpArrow))
                dir = Vector2.up * snakeSpeed;
    
            transform.Translate(dir);
        }
