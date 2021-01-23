    public class MyPageViewController : UIPageViewController
	{
		private List<ContentViewController> pages = new List<ContentViewController> ();
		public MyPageViewController () : base (UIPageViewControllerTransitionStyle.Scroll, UIPageViewControllerNavigationOrientation.Horizontal)
		{
			View.Frame = UIScreen.MainScreen.Bounds;
			pages.Add (new ContentViewController(0,UIColor.Red));
			pages.Add (new ContentViewController(1,UIColor.Green));
			pages.Add (new ContentViewController(2,UIColor.Blue));
			DataSource = new PageDataSource (pages);
			SetViewControllers (new UIViewController[] { pages [0] as UIViewController }, UIPageViewControllerNavigationDirection.Forward, false, null);
		}
	}
