    public void ListDevices()
    {
        var devices = new PortableDeviceCollection();
        devices.Refresh();
    
        foreach (var device in devices)
        {
            device.Connect();
            Console.WriteLine(@"DeviceId: {0}, FriendlyName: {1}", device.DeviceId, device.FriendlyName);
            device.Disconnect();
        }
    }
