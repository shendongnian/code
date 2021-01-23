	HttpNotificationChannel pushChannel;
	string channelName = "PushChannel";
	pushChannel = HttpNotificationChannel.Find(channelName);
	//Push Notifications
	if (pushChannel == null)
	{
		pushChannel = new HttpNotificationChannel(channelName);
		//// Register for all the events before attempting to open the channel.
		pushChannel.ChannelUriUpdated += new EventHandler<NotificationChannelUriEventArgs>(PushChannel_ChannelUriUpdated);
		pushChannel.ErrorOccurred += new EventHandler<NotificationChannelErrorEventArgs>(PushChannel_ErrorOccurred);
		// Register for this notification only if you need to receive the notifications while your application is running.
		pushChannel.ShellToastNotificationReceived += new EventHandler<NotificationEventArgs>(PushChannel_ShellToastNotificationReceived);
		pushChannel.Open();
		// Bind this new channel for toast events.
		pushChannel.BindToShellToast();
	}
	else
	{
		// The channel was already open, so just register for all the events.
		pushChannel.ChannelUriUpdated += new EventHandler<NotificationChannelUriEventArgs>(PushChannel_ChannelUriUpdated);
		pushChannel.ErrorOccurred += new EventHandler<NotificationChannelErrorEventArgs>(PushChannel_ErrorOccurred);
		// Register for this notification only if you need to receive the notifications while your application is running.
		pushChannel.ShellToastNotificationReceived += new EventHandler<NotificationEventArgs>(PushChannel_ShellToastNotificationReceived);
		
		// Display the URI for testing purposes. Normally, the URI would be passed back to your web service at this point.enter code here
		Deployment.Current.Dispatcher.BeginInvoke(() =>
		{
			//pushURI = pushChannel.ChannelUri.ToString();
			//MessageBox.Show(String.Format("Channel Uri is {0}", pushChannel.ChannelUri.ToString()));
			Notification.ChannelURI = pushChannel.ChannelUri.ToString();
		});
	}
-----------------------------------
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
