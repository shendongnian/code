    public AudioClip coinSound; //set in inspector    
    void OnTriggerEnter(Collider other)  // other is a reference to the other trigger collider we have touched
    {
        if (other.gameObject.tag == "Coin") 
        {
            coinSound.Play(); //play the coin sound
        }
    }
