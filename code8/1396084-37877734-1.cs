    try
    {
        Console.WriteLine(DeviceWrapperFactory.Connect(usbDevice).Name);
        // or
        var usbDeviceWrapper = DeviceWrapperFactory.Connect(usbDevice);
        Console.WriteLine(usbDeviceWrapper.Name);
        Console.WriteLine(usbDeviceWrapper.AnotherProperty);
    }
    catch (DeviceConnectionFailedException dcfe)
    {
        // ...
    }
    
