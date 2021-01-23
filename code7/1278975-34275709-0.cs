    void OnCollisionEnter2D(Collision2D col){
        Debug.Log ("Base touched");
        if (col.gameObject.tag == "Enemy"){
            if (Health > 0f){
                Debug.Log ("Enemy attacking base");
                StartCoroutine (enemyAttack ());
            }
        }
    }
    IEnumerator enemyAttack () {
        while (Health > 0f) {
            yield return new WaitForSeconds (2f);
            Health -= Enemy.Damage;
            Debug.Log ("Base health at: " + Health);
        }
    }
