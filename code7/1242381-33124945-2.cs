	public static Task<string> GetDevicePortName(CancellationToken cancellationToken)
	{
		// Get all available serial ports on system.
		var ports = SerialPort.GetPortNames();
		var serialPort = new SerialPort();
	
		serialPort.BaudRate = Constants.DeviceConstants.BaudRate;
		serialPort.Parity = Constants.DeviceConstants.SerialPortParity;
		serialPort.StopBits = Constants.DeviceConstants.SerialPortStopBits;
		serialPort.WriteTimeout = Constants.DeviceConstants.WriteTimeoutInMilliseconds;
	
		var taskCompletionSource = new TaskCompletionSource<string>();
		serialPort.DataReceived += (s, e) => 
		{
			var dataIn = (byte)serialPort.ReadByte();
			var receivedCharacter = Convert.ToChar(dataIn);
	
			if (receivedCharacter == Constants.DeviceConstants.SignalYes)
			{
				serialPort.Dispose();
				taskCompletionSource.SetResult(serialPort.PortName);
			}
		};
	
		foreach (var port in ports)
		{
			if (cancellationToken.IsCancellationRequested)
			{
				// Unregister from serialPort, and clean up whatever needs to be cleaned
				taskCompletionSource.SetResult(null);
				break;
			}
			
			serialPort.PortName = port;
	
			try
			{
				serialPort.Open();
				serialPort.Write(Constants.DeviceConstants.SignalDeviceDetect);
			}
			catch (IOException e) { }
			finally
			{
				serialPort.Dispose();
			}
		}
	
		return taskCompletionSource.Task;
	}
