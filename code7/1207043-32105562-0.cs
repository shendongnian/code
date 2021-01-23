	public static bool ShowYesNoMessage(string title, string message)
	{
		var resetEvent = new AutoResetEvent(false);
		var result = false;
		
		// Run in another thread so it doesn't block
		Task.Run(action: () =>
		{
			var alertController = UIAlertController.Create(title, message, UIAlertControllerStyle.Alert);
			alertController.AddAction(
				UIAlertAction.Create(
					"Yes", 
					UIAlertActionStyle.Default, 
					(action) => 
					{
						result = true;
						resetEvent.Set();
					}));
			alertController.AddAction(
				UIAlertAction.Create(
					"Yes", 
					UIAlertActionStyle.Default, 
					(action) => 
					{
						result = false;
						resetEvent.Set();
					}));
			
			InvokeOnMainThread(() => UIHelper.CurrentViewController.PresentViewController(alertController, true, null));
		});
		resetEvent.WaitOne();
		return result;
	}
