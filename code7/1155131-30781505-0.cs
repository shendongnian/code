        SerialPort sp;
		List<byte[]> buffer = new List<byte[]>();
		AutoResetEvent dataAvailable = new AutoResetEvent(false);
		Thread processThread;
		public void Start()
		{
			//Start the processing thread
			processThread = new Thread(ProcessData);
			processThread.Start();
			//Open the serial port at 3Mbps and with buffers of 3Mb
			sp = new SerialPort("COM12", 3145728, Parity.None, 8, StopBits.One);
			sp.ReadBufferSize = 1024 * 1024 * 3;
			sp.WriteBufferSize = 1024 * 1024 * 3;
			sp.DataReceived += sp_DataReceived;
			sp.Open();
		}
		//This thread processes the stored chunks doing the less locking possible
		void ProcessData(object state)
		{
			while (true)
			{
				dataAvailable.WaitOne();
				while (buffer.Count > 0)
				{
					byte[] chunk;
					lock (buffer)
					{
						chunk = buffer[0];
						buffer.RemoveAt(0);
					
					}
					//Process the chunk here as you wish
				
				}
			
			}
		
		}
		//The receiving function only stores data in a list of chunks
		void sp_DataReceived(object sender, SerialDataReceivedEventArgs e)
		{
			while (sp.BytesToRead > 0)
			{ 
				byte[] chunk = new byte[sp.BytesToRead];
				sp.Read(chunk, 0, chunk.Length);
				lock (buffer)
					buffer.Add(chunk);
				dataAvailable.Set();
			}
		}
