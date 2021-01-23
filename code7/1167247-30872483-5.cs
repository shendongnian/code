    UsbRelayDeviceInfo info;
    int i = 1;
    while ((info = UsbRelayDevice.Enumerate()) != null)
    {
        Console.WriteLine("Device " + (i++));
        Console.WriteLine("    Serial: " + info.SerialNumber);
        Console.WriteLine("    Device Path: " + info.DevicePath);
        Console.WriteLine("    Device Type: " + info.Type);
    }
