	public class MyTabBarController : UITabBarController
	{
		public string StringB
		{
			get;
			set;
		}
		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			ViewControllers = new UIViewController[]
			{
				new ControllerA
				{
					TabBarItem = new UITabBarItem("A", null, 0),
				},
				new ControllerB
				{
					TabBarItem = new UITabBarItem("B", null, 1),
				},
			};
		}
	}
