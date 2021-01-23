     string qFilter = SerialDevice.GetDeviceSelector("COM3");
     DeviceInformationCollection devices = await DeviceInformation.FindAllAsync(qFilter);
            if (devices.Any())
            {
                string deviceId = devices.First().Id;
                await OpenPort(deviceId);
            }
