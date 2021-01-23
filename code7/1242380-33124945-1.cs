	public async Task GetDevicePortNameAsync()
	{
		var cts = new CancellationTokenSource();
		var timeOutTask = Task.Delay(5000, cts.Token);
		var deviceNameTask = GetDevicePortName(cts.Token);
		
		var finishedTask = await Task.WhenAny(timeOut, deviceNameTask);
		if (finishedTask == timeOutTask)
		{
			// You've timed-out
		}
		// If you get here, the deviceName is available.
	}
	
