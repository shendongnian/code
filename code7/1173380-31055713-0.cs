    public partial class MasterViewController : UIViewController
    {
    	public void ReloadTable()
    	{
    		TableView.ReloadData ();
    	}
    }
    public partial class DetailViewController : UIViewController
    {
    	public override void ViewWillDisappear (bool animated)
    	{
    		var masterViewController = NavigationController.ViewControllers.OfType<MasterViewController> ();
    		if (masterViewController != null) {
    			masterViewController.ReloadTable ();
    		}
    
    		base.ViewWillDisappear (animated);
    	}
    }
