    if (pushChannel.ChannelUri != null)
    {
    	// This is raising my event to signal any subscribers
    	// that an new channelUri is available
    	RaiseGotPushUri(pushChannel.ChannelUri);
    
    	// Re-register the event handlers
    	pushChannel.ChannelUriUpdated += PushChannel_ChannelUriUpdated;
    	pushChannel.ShellToastNotificationReceived += PushChannel_ShellToastNotificationReceived;
    	pushChannel.ErrorOccurred += PushChannel_ErrorOccurred;
    }
    else
    {
    	// If we never got the Uri back, unbind and reset everything...
    	// Dispose of the old channel
    	pushChannel.ChannelUriUpdated -= PushChannel_ChannelUriUpdated;
    	pushChannel.ShellToastNotificationReceived -= PushChannel_ShellToastNotificationReceived;
    	pushChannel.ErrorOccurred -= PushChannel_ErrorOccurred;
    
    	if (pushChannel.IsShellToastBound) pushChannel.UnbindToShellToast();
    	pushChannel.Close();
    	pushChannel.Dispose();
    	
    	// ... and re-register the event handlers
    	pushChannel = new HttpNotificationChannel(channelName);//, _serviceName);
    	pushChannel.ChannelUriUpdated += PushChannel_ChannelUriUpdated;
    	pushChannel.ShellToastNotificationReceived += PushChannel_ShellToastNotificationReceived;
    	pushChannel.ErrorOccurred += PushChannel_ErrorOccurred;
    	
    	// Ask for a new Uri
    	pushChannel.Open();
    	// Set the HttpNotificationChannel to handle the appropriate push notifications
    	pushChannel.BindToShellToast();
    }
            
                
