    using Windows.Devices.SerialCommunication;
    using Windows.Devices.Enumeration;
    using Windows.Storage.Streams;
    //...   
    string selector = SerialDevice.GetDeviceSelector("COM3"); 
    DeviceInformationCollection devices = await DeviceInformation.FindAllAsync(selector);
    if(devices.Count > 0)
    {
        DeviceInformation deviceInfo = devices[0];
        SerialDevice serialDevice = await SerialDevice.FromIdAsync(deviceInfo.Id);
        serialDevice.BaudRate = 9600;
        serialDevice.DataBits = 8;
        serialDevice.StopBits = SerialStopBitCount.Two;
        serialDevice.Parity = SerialParity.None;
        DataWriter dataWriter = new DataWriter(serialDevice.OutputStream);
        dataWriter.WriteString("your message here");
        await dataWriter.StoreAsync();
        dataWriter.DetachStream();
        dataWriter = null;
    }
    else
    {
        MessageDialog popup = new MessageDialog("Sorry, no device found.");
        await popup.ShowAsync();
    }
