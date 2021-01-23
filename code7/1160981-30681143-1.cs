    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "levelExit")
        {
            Debug.Log("next level");
        }
    }
