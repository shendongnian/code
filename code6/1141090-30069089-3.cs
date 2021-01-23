    void OnCollisionEnter2D (Collision2D collision)
    	{
        
            //Get the referene of the EnemyScript attached to the GameObject that the bullet collided with.
    		EnemyScript hitEnemy = collision.collider.gameObject.GetComponent<EnemyScript> ();
    
            //Call the function
            hitEnemy.bulletHitMe();
    		CleanupBullet();
    	}
