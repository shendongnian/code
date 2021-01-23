    MouseState mouseState = Mouse.GetState();
    if (mouseState.LeftButton == ButtonState.Pressed)
    {
		foreach (Node n : nodes)
		{
			if (n.BoundingRectangle.Contains(mouseState.Position))
			{
				// TODO: Code to handle node being clicked...
			}
		}
    }
