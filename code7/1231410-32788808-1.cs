    void OnCollisionEnter2D (Collision2D col) {
        if (col.gameObject.tag == "enemyPlanet") {
            Instantiate (explosion, thingToMove.transform.position, thingToMove.transform.rotation);
            ui.gameOverActivated ();
            am.rocketBang.Play();
            Invoke( "over", 2.0f );
        
        }
    }
    
    void over(){
        Destroy (gameObject);
        Application.LoadLevel ("gameOverScene2");
    }
