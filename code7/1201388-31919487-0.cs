        private async void Discover_Click(object sender, EventArgs e)
        {
            var Services = await Windows.Devices.Enumeration.DeviceInformation.FindAllAsync(GattDeviceService.GetDeviceSelectorFromUuid(new Guid("6E400001-B5A3-F393-E0A9-E50E24DCCA9E")));
            GattDeviceService Service = await GattDeviceService.FromIdAsync(Services[0].Id);
            GattCharacteristic gattCharacteristic = Service.GetCharacteristics(new Guid("6E400002-B5A3-F393-E0A9-E50E24DCCA9E"))[0];
            var writer = new DataWriter();
            writer.WriteString("#FF00FF");
            var res = await gattCharacteristic.WriteValueAsync(writer.DetachBuffer(), GattWriteOption.WriteWithoutResponse);
        }
