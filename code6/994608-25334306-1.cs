	public class ControllerA : UIViewController
	{
		private int counter = 0;
		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			View.BackgroundColor = UIColor.White;
			var button = UIButton.FromType(UIButtonType.RoundedRect);
			button.Frame = View.Frame;
			button.SetTitle("Click me to change B's Text", UIControlState.Normal);
			button.TouchUpInside += (sender, e) => 
			{
				var parentController = ParentViewController as MyTabBarController;
				if (parentController != null)
				{
					parentController.StringB = "Here's a new string for you";
				}
			};
			View.AddSubview(button);
		}
	}
