      var entries = Db.Devices.Select(x => new DeviceDetailsModel
    {
        DeviceID = x.DeviceID;
        IPAddress = x.IPAddress;
        Alias = x.Alias;
        DeviceName = x.DeviceName;
    }).ToList();
