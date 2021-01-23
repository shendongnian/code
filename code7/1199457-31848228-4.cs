	void PushChannel_ChannelUriUpdated(object sender, NotificationChannelUriEventArgs e1)
	{
		try
		{
			Deployment.Current.Dispatcher.BeginInvoke(() =>
			{
				//MessageBox.Show(String.Format("Channel Uri is {0}", e1.ChannelUri.ToString()));
				Notification.ChannelURI = e1.ChannelUri.ToString();
			});
		}
		catch (Exception ex)
		{ }
	}
	void PushChannel_ErrorOccurred(object sender, NotificationChannelErrorEventArgs e2)
	{
		try
		{
			// Error handling logic for your particular application would be here.
			Deployment.Current.Dispatcher.BeginInvoke(() =>
			{
				//MessageBox.Show(String.Format("A push notification {0} error occurred.  {1} ({2}) {3}", e2.ErrorType, e2.Message, e2.ErrorCode, e2.ErrorAdditionalData));
			});
		}
		catch (Exception ex)
		{ }
	}
