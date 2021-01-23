    var selector = BluetoothDevice.GetDeviceSelector();
    var devices = await DeviceInformation.FindAllAsync(selector);
    foreach (var device in devices)
    {
        var bluetoothDevice = await BluetoothDevice.FromIdAsync(device.Id);
        if (bluetoothDevice != null)
        {
            Debug.WriteLine(bluetoothDevice.BluetoothAddress);
        }
        Debug.WriteLine(device.Id);
        foreach(var property in device.Properties)
        {
            Debug.WriteLine("   " + property.Key + " " + property.Value);
        }
    }
