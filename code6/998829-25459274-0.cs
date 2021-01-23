    void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Laser") || collider.CompareTag("Player")) { //Tag is name of prefab.
            //When the laser hits the enemy, destroy the enemy.
            Destroy(this.gameObject);
        }
        
        if(collider.CompareTag("Enemy")) {
            if (Player.score < 500 || Player.playerLives >= 1) {
                for (int enemies = 0; enemies < 3; enemies++) {
                    print("Enemies: " + enemies);
                    Vector3 nposition = new Vector3 (Random.Range (llocation, rlocation), ylocation, 0);
                    Instantiate(gameObject, nposition, Quaternion.identity);
                    //TS.position += (Vector3.down * currentSpeed * Time.deltaTime);
                }
            }
        }
    }
