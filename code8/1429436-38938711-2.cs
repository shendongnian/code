    public class TestViewCtonroller : UIViewController
	{
		public TestViewCtonroller ()
		{
			this.View.BackgroundColor = UIColor.Red;
		}
		public override UIStatusBarStyle PreferredStatusBarStyle ()
		{
			return UIStatusBarStyle.LightContent;
		}
		public override bool PrefersStatusBarHidden ()
		{
			return true;
		}
	}
