        private void SetupBluetooth()
        {
            Watcher = new BluetoothLEAdvertisementWatcher { ScanningMode = BluetoothLEScanningMode.Active };
            Watcher.Received += DeviceFound;
            DeviceWatcher = DeviceInformation.CreateWatcher();
            DeviceWatcher.Added += DeviceAdded;
            DeviceWatcher.Updated += DeviceUpdated;
            StartScanning();
        }
        private void StartScanning()
        {
            Watcher.Start();
            DeviceWatcher.Start();
        }
        private void StopScanning()
        {
            Watcher.Stop();
            DeviceWatcher.Stop();
        }
        private async void DeviceFound(BluetoothLEAdvertisementWatcher watcher, BluetoothLEAdvertisementReceivedEventArgs btAdv)
        {
            if (_devices.Contains(btAdv.Advertisement.LocalName))
            {
                await Dispatcher.RunAsync(CoreDispatcherPriority.Low, async () =>
                {
                    Debug.WriteLine($"---------------------- {btAdv.Advertisement.LocalName} ----------------------");
                    Debug.WriteLine($"Advertisement Data: {btAdv.Advertisement.ServiceUuids.Count}");
                    var device = await BluetoothLEDevice.FromBluetoothAddressAsync(btAdv.BluetoothAddress);
                    var result = await device.DeviceInformation.Pairing.PairAsync(DevicePairingProtectionLevel.None);
                    Debug.WriteLine($"Pairing Result: {result.Status}");
                    Debug.WriteLine($"Connected Data: {device.GattServices.Count}");
                });
            }
        }
        private async void DeviceAdded(DeviceWatcher watcher, DeviceInformation device)
        {
            if (_devices.Contains(device.Name))
            {
                try
                {
                    var service = await GattDeviceService.FromIdAsync(device.Id);
                    Debug.WriteLine("Opened Service!!");
                }
                catch
                {
                    Debug.WriteLine("Failed to open service.");
                }
            }
        }
        private void DeviceUpdated(DeviceWatcher watcher, DeviceInformationUpdate update)
        {
            Debug.WriteLine($"Device updated: {update.Id}");
        }
