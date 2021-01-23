	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}
		// Button: starts Task version
		private void button1_Click(object sender, EventArgs e)
		{
			StartReceiveTask();
		}
		// Button: starts Thread version
		private void button2_Click(object sender, EventArgs e)
		{
			StartReceiveThread();
		}
		// Start the Receive loop as a Task
		public void StartReceiveTask()
		{
			System.Threading.Tasks.Task.Run(() => receiveThreadFunc());
		}
		// Start the Receive loop as a Thread
		public void StartReceiveThread()
		{
			var thd = new System.Threading.Thread(receiveThreadFunc);
			thd.Start();
		}
		// Called when the Receive loop finishes
		public void DataReceived(string data)
		{
			// do something with the data here
		}
		// The Receive loop, used by both Thread and Task forms.
		public void receiveThreadFunc()
		{
			using (var serial1 = new System.IO.Ports.SerialPort("COM1", 9600, System.IO.Ports.Parity.None, 8, System.IO.Ports.StopBits.One))
			{
				// open serial port
				if (!serial1.IsOpen)
					serial1.Open();
				// send init command
				var initCommand = new byte[13];
				serial1.Write(initCommand, 0, initCommand.Length);
				// get start time
				DateTime start = DateTime.Now;
				// buffer for pushing received string data into
				StringBuilder indata = new StringBuilder();
				// loop until at most 10 seconds have passed 
				while ((DateTime.Now - start).TotalSeconds < 2)
				{
					if (serial1.BytesToRead > 0)
					{
						// allocate a buffer, up to 1K in length, to receive into
						int blen = Math.Min(1024, serial1.BytesToRead);
						byte[] buffer = new byte[blen];
						// read chunks of data until none left
						while (serial1.BytesToRead > 0)
						{
							int rc = serial1.Read(buffer, 0, blen);
							// convert data from ASCII format to string and append to input buffer
							indata.Append(Encoding.ASCII.GetString(buffer, 0, rc));
						}
					}
					else
						System.Threading.Thread.Sleep(25);
					// check for EOL
					if (indata.Length > 0 && indata.ToString().EndsWith("\r\n"))
						break;
				}
				if (indata.Length > 0)
				{
					// post data to main thread, via Invoke if necessary:
					string data = indata.ToString();
					if (this.InvokeRequired)
						this.Invoke(new Action(() => { DataReceived(data); }));
					else
						this.DataReceived(data);
				}
			}
		}
	}
