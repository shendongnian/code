    public void OnCollisionEnter(Collision obj_collision)   
    {
    	if(obj_collision.gameObject.name == "HitScore")
    	{
    		Debug.Log("Collision");
    		Puntuacion puntuacionScript = gameObject.GetComponent<Puntuacion>();
    		puntuacionScript.incrementarPuntuacion();
    		Destroy(gameObject,2.0F);
    	}
    }
