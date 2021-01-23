	public class CustomSeque : UIStoryboardSegue // or UIStoryboardPopoverSegue depending upon UI design so you can "POP" controller
	{
		public CustomSeque(String identifier, UIViewController source, UIViewController destination) : base (identifier, source, destination) { }
		public override void Perform()
		{
			if (Identifier == "StackOverflow")
			{
				// Are you using a NavigationController?
				if (SourceViewController.NavigationController != null)
					SourceViewController.NavigationController?.PushViewController(DestinationViewController, animated: true);
				else 
					SourceViewController.ShowViewController(DestinationViewController, this);
			} else
				base.Perform();
		}
	}
