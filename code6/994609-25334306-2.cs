    public class ControllerB : UIViewController
	{
		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			View.BackgroundColor = UIColor.White;
			LabelB = new UILabel(View.Frame)
			{
				Text = "B's Default Text",
				TextColor = UIColor.Black,
			};
			View.AddSubview(LabelB);
		}
		public override void ViewWillAppear (bool animated)
		{
			base.ViewWillAppear (animated);
			var parent = ParentViewController as MyTabBarController;
			if (parent != null && !string.IsNullOrEmpty(parent.StringB))
			{
				LabelB.Text = parent.StringB;
			}
		}
		public UILabel LabelB {
			get;
			set;
		}
	}
