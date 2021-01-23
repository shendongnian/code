    //If enemy touches the base 
    void OnCollisionEnter2D(Collision2D col){
        Debug.Log ("Base touched");
        if(col.gameObject.tag == "Enemy"){
            enemy.isAttacking = true;
            if(Health > 0f){
                Debug.Log ("Enemy attacking base");
                StartCoroutine("enemyAttack");
            }
            else{
                enemy.isAttacking = false;
            }
        
        }
        else{ 
            enemy.isAttacking = false;
            }
    }
