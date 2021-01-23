    void Update () 
    {
        jump = Input.GetKey(KeyCode.Space);
        if (jump == true)
            StartCoroutine(jumpTest());
    }
  
