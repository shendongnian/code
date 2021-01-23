    string aqs = SerialDevice.GetDeviceSelector("COM3");
    DeviceInformationCollection dlist = await DeviceInformation.FindAllAsync(aqs);
    if (dlist.Any())
    {
     deviceId = dlist.First().Id;
    }
    using (SerialDevice serialPort = await SerialDevice.FromIdAsync(deviceId))
    {
    // .....
    }
