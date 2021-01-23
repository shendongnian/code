    private void SerialPortDataSource_DataReceived(object sender, SerialDataReceivedEventArgs e)
		{
		    try
		    {
				if (BytesToRead > 0)
				{
					var buffor = new byte[BytesToRead];
					Read(buffor, 0, buffor.Length);
					_receivedBytes = buffor;
					//wConsole.WriteLine(ArrayExtension.ToString(buffor));
					var dataLogger = DataLogger;
					if (dataLogger != null)
					{
						dataLogger.WriteLine("- DR - {0}", true, BitConverterExtension.ToHexString(buffor));
					}
					if (OnDataReceived != null)
					{
						OnDataReceived(this, buffor);
					}
				}
		    }
		    catch (InvalidOperationException)
		    {
				// sometimes DataReceived event is invoked after port is closed which causes InvalidOperationException
		    }
		}
