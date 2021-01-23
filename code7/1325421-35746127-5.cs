    // this is the class from above
	public class CheckBoxGUI : GUIElement
    {
		public bool IsChecked { get; set; }
		
		readonly Action<CheckBoxGUI> OnCheckedChanged;
        public CheckBoxGUI(Action<CheckBoxGUI> onCheckedChanged, Rectangle rectangle)
			: base(rectangle) // we need to pass the rectangle to the base class
        {
            OnCheckedChanged = setter;
        }
		
		// Note that this method returns bool, unlike 'void Update'.
		// Also, intersections should be handled here, not outside.
		public override bool Update(GameTime gameTime, InputState inputState)
		{
		    var handled = base.Update(gameTime, inputState);
			if (!handled)
				return false;
			
			// if we are here, it means we need to handle the inputState
			IsChecked = !IsChecked;
			OnCheckedChanged(this);
		}
		
		... drawing methods, load/unload content
	}
