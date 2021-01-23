    using Windows.Devices.SerialCommunication;
    using Windows.Devices.Enumeration;
        
    //...   
    var selector = SerialDevice.GetDeviceSelector("COM3"); 
    DeviceInformationCollection devices = await DeviceInformation.FindAllAsync(selector);
    if(devices.Count > 0)
    {
        var deviceInfo = devices[0];
        var serialDevice = await SerialDevice.FromIdAsync(deviceInfo.Id);
        serialDevice.BaudRate = 9600;
        serialDevice.DataBits = 8;
        serialDevice.StopBits = SerialStopBitCount.Two;
        serialDevice.Parity = SerialParity.None;
        var dataWriter = new Windows.Storage.Streams.DataWriter(serialDevice.OutputStream);
        dataWriter.WriteString("tell your arduino what to do here");
        await dataWriter.StoreAsync();
        dataWriter.DetachStream();
        dataWriter = null;         
    }
    else
    {
        var popup = new MessageDialog("No devices found.");
        await popup.ShowAsync();
    }
