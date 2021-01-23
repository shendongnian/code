        animation.Play();
		if (Input.GetKey(KeyCode.W))
		{
			animation["Walking"].speed = 1;
		}
		if (Input.GetKey(KeyCode.S))
		{
			animation["Walking"].speed = -1;
		}
		if (Input.GetKeyUp(KeyCode.W))
		{
			animation["Walking"].speed = 0;
		}
		
		if (Input.GetKeyUp(KeyCode.S))
		{
			animation["Walking"].speed = 0;
		}
