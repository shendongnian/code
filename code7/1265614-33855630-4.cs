	public void activeDeviceProcessFormClosed(int deviceNumber)
	{
		 this.Invoke((MethodInvoker)delegate
		 {
			var device = activeDeviceProcessForms.FirstOrDefault(
							i => i.Device.DeviceNumber == deviceNumber);
							
			if (device != null)
				activeDeviceProcessForms.Remove(device);
		 });
	}
