    Vector2 mousePosition = new Vector2(this.mouseState.X, this.mouseState.Y);
    Vector2 objectPosition = Vector2.Zero;
    this.grabbedObject = GetClickedObject(mousePosition, out objectPosition);
    if (this.grabbedObject != null)
    {
        this.grabOffset = new Vector2(
			mousePosition.X - objectPosition.X,
			mousePosition.Y - objectPosition.Y);
    }
    
	private object GetClickedObject(Vector2 pMousePosition, out Vector2 pObjectPosition)
	{
		Object clickedObject = null;
		// search first object you clicked on and set to clickedObject	
		pObjectPosition = clickedObject == null ? Vector2.Zero : clickedObject.Position;
		
		return clickedObject;
	}
