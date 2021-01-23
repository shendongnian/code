    var enumerator = new NAudio.CoreAudioApi.MMDeviceEnumerator();
    var endpoints = enumerator.EnumerateAudioEndPoints(
        DataFlow.Render,
        DeviceState.Unplugged | DeviceState.Active);
    foreach (var endpoint in endpoints)
    {
        Console.WriteLine("{0} - {1}", endpoint.DeviceFriendlyName, endpoint.State);
    }
