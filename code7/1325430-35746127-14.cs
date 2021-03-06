	public class CheckBoxGUI : GUIElement
    {
		public bool IsChecked { get; set; }
		
		// instead of using the event, you can use a single delegate
		readonly Action<CheckBoxGUI> OnCheckedChanged;
        public CheckBoxGUI(Action<CheckBoxGUI> onCheckedChanged, Rectangle rectangle)
			: base(rectangle) // we need to pass the rectangle to the base class
        {
            OnCheckedChanged = onCheckedChanged;
        }
		
		public override bool Update(GameTime gameTime, InputState inputState)
		{
		    if (WasClicked(inputState)) // imaginary method
			{
				// if we are here, it means we need to handle the inputState
				IsChecked = !IsChecked;
				
				// this method will be invoked 
				OnCheckedChanged(this);
                return true;
			} 
            else 
            {
                return false;
            }
		}
		
		... drawing methods, load/unload content
	}
	
