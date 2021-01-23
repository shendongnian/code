    void Start() 
    {
        StartCoroutine(crMoveIt());
    }
    
    private IEnumerator crMoveIt() 
    {
        while(true) // have a bool var for this
        {
            if(Input.GetKeyDown(KeyCode.A)) 
            {
                // Move object here
            }
        }
    }
