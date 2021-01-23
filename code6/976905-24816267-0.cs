    public Puntuacion puntuacion = new Puntuacion();
    	
    public void OnCollisionEnter(Collision obj_collision)   
    {	
    	if(obj_collision.gameObject.name == "HitScore")
    	{
    		Debug.Log("Collision");
    		puntuacion.incrementarPuntuacion();
    		Destroy(gameObject,2.0F);
    	}
    }
