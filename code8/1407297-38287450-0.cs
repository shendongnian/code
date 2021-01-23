    void OnTriggerEnter (Collider obstacle)
    	{
    		if (obstacle.gameObject.tag == "Pick Axe")
    		{
    			obstacle.gameObject.SetActive (false);
    		}
    	}
