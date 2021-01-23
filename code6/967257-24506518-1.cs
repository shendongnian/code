    void GetRandomBallValue()
    {
     ballValue=new Random().Next(1,100);
    }
         void OnCollisionEnter2D (Collision2D collision) {
            if (collision.gameObject.tag == "Bomb") {
                GetRandomBallValue();
                score =ballValue * 2;
                UpdateScore ();
            }
        }
