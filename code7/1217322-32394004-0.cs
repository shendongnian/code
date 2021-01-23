    push.OnChannelCreated += push_OnChannelCreated;
    push.OnChannelDestroyed += push_OnChannelDestroyed;
    push.OnChannelException += push_OnChannelException;
    push.OnDeviceSubscriptionChanged += push_OnDeviceSubscriptionChanged;
    push.OnDeviceSubscriptionExpired += push_OnDeviceSubscriptionExpired;
    push.OnNotificationFailed += push_OnNotificationFailed;
    push.OnNotificationRequeue += push_OnNotificationRequeue;
    push.OnNotificationSent += push_OnNotificationSent;
    push.OnServiceException += push_OnServiceException;
    
    // not sure about this one
    push.RegisterGcmService(new GcmPushChannelSettings(ConfigurationManager.AppSettings["GCM_Development_ServerKey"].ToString()));
    
    foreach(var recipient in recipients)
    {
        // do other things here
    }
