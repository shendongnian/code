    public override void ReceivedLocalNotification(UIApplication application, UILocalNotification notification)
	{
		UIAlertView alert = new UIAlertView () { Title = notification.AlertAction, Message = notification.AlertBody };
		alert.AddButton("OK");
		alert.Show ();
		// CLEAR BADGES
		UIApplication.SharedApplication.ApplicationIconBadgeNumber = 0;
	}
