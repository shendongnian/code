        private void StartWatcher()
        {
            ConnectedDevices = new List<string>();
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
        private async void DeviceFound(BluetoothLEAdvertisementWatcher watcher, BluetoothLEAdvertisementReceivedEventArgs btAdv)
        {
            if (!ConnectedDevices.Contains(btAdv.Advertisement.LocalName) && _devices.Contains(btAdv.Advertisement.LocalName))
            {
                await Dispatcher.RunAsync(CoreDispatcherPriority.Low, async () =>
                {
                    var device = await BluetoothLEDevice.FromBluetoothAddressAsync(btAdv.BluetoothAddress);
                    if (device.GattServices.Any())
                    {
                        ConnectedDevices.Add(device.Name);
                        device.ConnectionStatusChanged += (sender, args) =>
                        {
                            ConnectedDevices.Remove(sender.Name);
                        };
                        SetupWaxStream(device);
                    } else if (device.DeviceInformation.Pairing.CanPair && !device.DeviceInformation.Pairing.IsPaired)
                    {
                        await device.DeviceInformation.Pairing.PairAsync(DevicePairingProtectionLevel.None);
                    }
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
                    var characteristics = service.GetAllCharacteristics();
                }
                catch
                {
                    Debug.WriteLine("Failed to open service.");
                }
            }
        }
        private async void DeviceUpdated(DeviceWatcher watcher, DeviceInformationUpdate update)
        {
            var device = await DeviceInformation.CreateFromIdAsync(update.Id);
            if (_devices.Contains(device.Name))
            {
                try
                {
                    var service = await GattDeviceService.FromIdAsync(device.Id);
                    var characteristics = service.GetAllCharacteristics();
                }
                catch
                {
                    Debug.WriteLine("Failed to open service.");
                }
            }
        }
