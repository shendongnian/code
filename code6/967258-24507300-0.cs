    Random rnd = new Random();
    void GetRandomBallValue()
    {
        ballValue=rnd.Next(1,101); //excluding 101 - if you do not need 100, call Next(1,100);
    }
    
    void OnCollisionEnter2D (Collision2D collision) {
        if (collision.gameObject.tag == "Bomb") {
            GetRandomBallValue();
            score =ballValue * 2;
            UpdateScore ();
         }
    }
