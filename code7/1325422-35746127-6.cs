    public void Update(GameTime gameTime)
	{
		var mouse = Mouse.GetState();
		var inputState = new InputState()
		{
			Pressed = mouse.LeftButton == ButtonState.Pressed,
			Position = mouse.Position
		};
		
		foreach (var element in this.Elements)
		{
			element.Update(gameTime, inputState);
		}
	}
