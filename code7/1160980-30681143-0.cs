    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.tag == "levelExit")
        {
            Debug.Log("next level");
        }
    }
