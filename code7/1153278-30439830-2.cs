	public override void Clicked (UIAlertView alertview, nint buttonIndex)
	{
		if (buttonIndex == 1) {
			var settingsString = UIKit.UIApplication.OpenSettingsUrlString;
			var url = new NSUrl (settingsString);
			UIApplication.SharedApplication.OpenUrl (url);
		}
	  }
    }
