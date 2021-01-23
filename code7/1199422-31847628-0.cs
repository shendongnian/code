    private Vector3 prevMousePosition = Vector3.zero;
    void Update()
    {
        if(Input.anyKeyDown || Input.mousePosition != prevMousePosition)
             RestartGameInvoke();
    
         prevMousePosition = Input.mousePosition;
    }
