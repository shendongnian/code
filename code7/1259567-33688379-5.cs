	protected void Draw(GameTime gameTime)
	{
		switch (_state)
		{
			case States.InMenu:
				DrawMenu();
				break;
			case States.LeavingMenu:
				ShowTimer();
				break;
		}
	}
