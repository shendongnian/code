	void OnCollisionEnter2D(Collision2D coll) 
	{
		Vector3 collPosition = coll.transform.position;
		
		if(collPosition.y > transform.position.y)
		{
			Debug.Log("The object that hit me is above me!");
		}
		else
		{ 
			Debug.Log("The object that hit me is below me!");
		}
		if (collPosition.x > transform.position.x)
        {
			Debug.Log ("The object that hit me is to my right!");
		} 
		else 
		{
			Debug.Log("The object that hit me is to my left!");
		}
	}
