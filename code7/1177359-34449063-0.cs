    public class CalendarButton: UIButton
	{
		public int ID;
		public int State;
		public CalendarButton (string text, int id)
		{
			ID = id;
			SetTitle (text, UIControlState.Normal);
		}
		public CalendarButton ():base(UIButtonType.System){
			State = 0;
		}
		public CalendarButton(IntPtr handle) : base(handle) { }
    }
