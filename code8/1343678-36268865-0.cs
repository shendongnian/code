    void OnCollisionEnter(Collision col){
        GameObject collidedWith = col.gameObject;
        if(collidedWith.tag == "PlayerTagName"){
            //do player collided logic here
        }
        else if(collidedWith.tag == "EnemyTagName"){
            //do enemy collided logic here
        }
    }
