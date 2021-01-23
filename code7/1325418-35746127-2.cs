	public class GUIElement
	{
		public Rectangle Bounds { get; set; }
	
		public GUIElement(Rectangle rect)
		{
			Bounds = rect;
		}
		
		public virtual bool Update(GameTime game, InputState inputState)
		{
		    // if another element already handled this click,
			// no need to bother
			if (inputState.Handled)
				return false;			
			
			// you should actually check if mouse was both clicked and released 
			// within these bounds, but this is just a demo:
			if (!inputState.Pressed)
                return false;
			
            // within bounds?
			if (!this.Bounds.Contains(inputState.Position))
				return false;
				
			// mark as handled: we don't want this event to 
			// propagate further
			inputState.Handled = true;
			return true;
		}
	
		public virtual void Draw(GameTime gameTime, SpriteBatch sb) { }
	}
	
