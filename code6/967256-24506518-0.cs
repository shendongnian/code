     void OnCollisionEnter2D (Collision2D collision) {
        if (collision.gameObject.tag == "Bomb") {
            score =new Random().Next(1,100);
            UpdateScore ();
        }
    }
