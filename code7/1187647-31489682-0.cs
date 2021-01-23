    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player") {
            Enemy.Found = true; //if the player is in shooting range
            Enemy.Idle = false; 
        } 
    }
    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player") {
            Enemy.Exit2DTrigger();
        } 
    }
