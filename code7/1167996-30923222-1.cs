    // Find the device
    var bluetoothDevicesSpp = await DeviceInformation.FindAllAsync(RfcommDeviceService.GetDeviceSelector(RfcommServiceId.SerialPort));
    var bluetoothDeviceHc06 = bluetoothDevicesSpp.SingleOrDefault(d => d.Name == "HC-06");
    var serviceRfcomm = await RfcommDeviceService.FromIdAsync(bluetoothDeviceHc06.Id);
    StreamSocket socket = new StreamSocket();
    await socket.ConnectAsync(serviceRfcomm.ConnectionHostName, serviceRfcomm.ConnectionServiceName, SocketProtectionLevel.BluetoothEncryptionAllowNullAuthentication);
    DataWriter writer = new DataWriter(socket.OutputStream);
    DataReader reader = new DataReader(socket.InputStream);
