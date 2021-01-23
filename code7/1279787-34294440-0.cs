    void OnCollisionEnter2D(Collision2D col){
        Debug.Log ("Base touched");
        if(col.gameObject.tag == "Enemy" && Health > 0f){
            enemy.isAttacking = true;
            Debug.Log ("Enemy attacking base");
            StartCoroutine("enemyAttack");
        }
        else{
            enemy.isAttacking = false;
        }
    }
