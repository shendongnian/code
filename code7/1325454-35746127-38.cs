	// this is the class from above
	public class CheckBoxGUI : GUIElement
	{
		public bool IsChecked { get; set; }
		public event Action<CheckBoxGUI> CheckedChanged;
		protected virtual void OnCheckedChanged()
		{
			var h = CheckedChanged;
			if (h != null)
				h(this);
		}
		
		public CheckBoxGUI(Rectangle rectangle)
			: base(rectangle) // we need to pass the rectangle to the base class
		{ }
		
		// the rest of the class remains the same
	}
	
