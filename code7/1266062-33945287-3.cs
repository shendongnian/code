    var enumerator = new NAudio.CoreAudioApi.MMDeviceEnumerator();
    
    // Allows you to enumerate rendering devices in certain states
    var endpoints = enumerator.EnumerateAudioEndPoints(
        DataFlow.Render,
        DeviceState.Unplugged | DeviceState.Active);
    foreach (var endpoint in endpoints)
    {
        Console.WriteLine("{0} - {1}", endpoint.DeviceFriendlyName, endpoint.State);
    }
    // Aswell as hook to the actual event
    enumerator.RegisterEndpointNotificationCallback(new NotificationClient());
