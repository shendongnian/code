    // Check to see if the bullet is colliding with anything.
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Terrain") 
        {
            this.audio.Play ();
            int smokeIndex = 0;
            GameObject smoke = (GameObject) Instantiate(bulletSmoke[smokeIndex],transform.position,transform.rotation); 
            Destroy (smoke, 5f);
            Destroy (gameObject,0.05f);
        }
        if (col.gameObject.tag == "Enemy") 
        { 
            int[] hit = new int[] {1, 1};
            col.gameObject.SendMessage("TakeHit", hit);
            // If you don't want to require a receiver
            // col.gameObject.SendMessage("TakeHit", hit, SendMessageOptions.DontRequireReceiver);
        }
    }
