	DateTime timeOfEscPressed;
	protected virtual void Update(GameTime gameTime)
	{
		switch (_state)
		{
			case States.Initialising:
				break;
			case States.InMenu:
                // *** pseudo-code here ***
				// if ESC pressed then 
                //    _state = States.LeavingMenu
                //    timeOfEscPressed = DateTime.Now;
				break;
			case States.LeavingMenu:
				// stay in this state for 3 seconds
				if ((DateTime.Now - timeOfEscPressed).TotalSeconds >= 3)
				{
					_state = States.InGame;
				}
				break;
			case States.InGame:
				if (menuKeyPressed) // pseudo code
				{
					_state = States.InMenu;
					timeOfEscPressed = DateTime.Now;
				}
				break;
		}
	}
