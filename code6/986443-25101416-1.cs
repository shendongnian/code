	partial class nextView : UIViewController
	{
    		public nextView (IntPtr handle) : base (handle)
    		{
    		}
    		public override void ViewDidLoad()
    		{
        		base.ViewDidLoad();
        		//perform initialization here
        		lastLabel.Text = Core.getdata ();
    		}
	}
