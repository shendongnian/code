    void OnCollisionEnter(Collision col)
	{
	
		if(col.gameObject.tag == "bomb")
		{
			// I got hit by a bomb! 
			Instantiate(explosion, col.gameObject.transform.position, Quaternion.identity);
			//ParticleSystem temp = ParticleSystem2;
			//temp.emission.enabled = false;
			ParticleSystem.EmissionModule em = ParticleSystem2.emission; 
			em.enabled = false;
			ParticleSystem2.Stop ();
			gameObject.GetComponent<ParticleSystem>().enableEmission = false;
			gameObject.GetComponent<ParticleSystem>().Stop();
