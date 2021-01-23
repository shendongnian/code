	public async Task GetDevicePortNameAsync()
	{
		var timeOutTask = Task.Delay(5000);
		var deviceNameTask = GetDevicePortName();
		
		var finishedTask = await Task.WhenAny(timeOut, deviceNameTask);
		if (finishedTask == timeOutTask)
		{
			// You've timed-out
		}
		// If you get here, the deviceName is available.
	}
	
