    var deviceList = await DeviceInformation.FindAllAsync(GattDeviceService.GetDeviceSelectorFromUuid(GattServiceUuids.GenericAccess), null);
    int count = deviceList.Count();
    if (count > 0)
    {
        var deviceInfo = deviceList.Where(x => x.Name == "XC-Tracer").FirstOrDefault();
        if (deviceInfo != null)
        {
            if (deviceInfo.IsEnabled)
            {
                var bleDevice = await GattDeviceService.FromIdAsync(deviceInfo.Id);
                var deviceServices = bleDevice.GattServices;
            }
        }
    }
