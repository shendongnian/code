    void Update()
	{
		if(!isMoving) 
		{
			CheckInput();
			if(isMoving) 
			{
				input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
				if(!allowDiagonals) 
				{
					if(Mathf.Abs(input.x) > Mathf.Abs(input.y)) 
					{
						input.y = 0;
					} else 
					{
						input.x = 0;
					}
				}
				StartCoroutine(move(transform));
			}
		}
    }
