	public void activeDeviceProcessFormClosed(int deviceNumber)
	{
		 this.Invoke((MethodInvoker)delegate
		 {
			activeDeviceProcessForms.RemoveAll(i => i.Device.DeviceNumber == deviceNumber);
		 });
	}
	
