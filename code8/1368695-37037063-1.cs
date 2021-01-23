    public partial class ShowOffersViewController : UIViewController
	{
		public ShowOffersViewController (IntPtr handle) : base (handle)
		{
		}
		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			button.TouchUpInside += Button_TouchUpInside;
		}
		public delegate void ButtonPressedHandler();
		public event ButtonPressedHandler ButtonPressed;
		public void Button_TouchUpInside (object sender, EventArgs e)
		{
			if (ButtonPressed != null) {
				ButtonPressed.Invoke ();
			}
		}
	}
