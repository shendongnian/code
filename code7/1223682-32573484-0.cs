    void OnCollisionEnter2D (Collider2D other)
    {
        //ignore collider from Player
        if(!other.transform.name.Equals("Player")
        {
            //do something here
        }
    
    }
    
    void OnTriggerEnter2D (Collider2D other)
    {
        // Don't ignore trigger from Player
    
        //do something here
    }
