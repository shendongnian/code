    private async Task PopulateDeviceList()
	{
		outputDevicesListBox.Items.Clear();
		outputDevices = await DeviceInformation.FindAllAsync(MediaDevice.GetAudioRenderSelector());
		outputDevicesListBox.Items.Add("-- Pick output device --");
		foreach (var device in outputDevices)
		{
			outputDevicesListBox.Items.Add(device.Name);
		}
	}
