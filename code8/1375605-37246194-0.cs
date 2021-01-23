    void Update() 
    {
        if (Input.touchCount > 0)
        {
            for (int i = 0; i < Input.touchCount; i++) 
            {
                myTouch = Input.GetTouch(i);
                // ...
            }
        }
    }
    
    
