    BleWatcher = new BluetoothLEAdvertisementWatcher 
    { 
        ScanningMode = BluetoothLEScanningMode.Active
    };
    BleWatcher.Start();
    BleWatcher.Received += async (w, btAdv) => {
        var device = await BluetoothLEDevice.FromBluetoothAddressAsync(btAdv.BluetoothAddress);
    Debug.WriteLine($"BLEWATCHER Found: {device.name}");
        // SERVICES!!
        var gatt = await device.GetGattServicesAsync();
        Debug.WriteLine($"{device.Name} Services: {gatt.Services.Count}, {gatt.Status}, {gatt.ProtocolError}");
        // CHARACTERISTICS!!
        var characs = await gatt.Services.Single(s => s.Uuid == SAMPLESERVICEUUID).GetCharacteristicsAsync();
        var charac = characs.Single(c => c.Uuid == SAMPLECHARACUUID);
        await charac.WriteValueAsync(SOMEDATA);
    };
