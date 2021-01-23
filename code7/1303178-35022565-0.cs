	private bool toMoveRight = false;
    ...
	void FixedUpdate()
	{
		if (toMoveRight)
		{
			// YOUR EXISTING LOGIC HERE
			//...
			toMoveRight = false;
		}
	}
    ....
	public void MoveRight()
	{
		toMoveRight = true;
	}
	//USE SIMILAR FUNCTIONS TO MOVE LEFT, JUMP, OTHER MOVEMENTS THAT YOU NEED
