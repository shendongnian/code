    bool afterFirstFrame = false;
    void Update()
    {
        if (afterFirstFrame)
        {
            //Put your code here
    
            if (Input.GetKey(KeyCode.Space))
            {
                Debug.Log("Hello!");
            }
            else
            {
                Debug.Log("Not down!");
            }
        }
    
        if (!afterFirstFrame)
        {
            afterFirstFrame = true;
        }
    }
