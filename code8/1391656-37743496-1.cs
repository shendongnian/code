    public class MessageEventArgs : EventArgs
	{
		public string Message { get; private set;}
	
		public MessageEventArgs(string message)
		{
		    Message = message;
		}
	}
	
	public class MyReceiver : IDisposable
    {
		private Thread _thread;
		private ManualResetEvent _terminating = new ManualResetEvent(false);
	
		public void Start()
		{
			_thread = new Thread(() =>
			{
				try
				{
					IntPtr hPipe;
					string dwWritten;
					byte[] buffer = new byte[BUFSIZE];
					NamedPipeClientStream pipeClient = new NamedPipeClientStream(".","testpipe", PipeDirection.In, PipeOptions.WriteThrough);
					if (pipeClient.IsConnected != true) { pipeClient.Connect(); }
					StreamReader sr = new StreamReader(pipeClient);
					string temp;
					while(!_terminating.WaitOne(0))
					{
						temp = "";
						temp = sr.ReadLine();
						if (temp != null)
						{
							OnMessage?.Invoke(temp);
						}
						if (temp != "QUIT")
						{
							sw.WriteLine("Response");
							sw.Flush();
							pipeClient.WaitForPipeDrain();
						}
						else
						{
							sw.WriteLine("Response");
							_terminating.Set();
						}
					}
				}
				catch (Exception ex)
				{
					throw new Exception("Exception: " + ex.Message);
				}				
			});
			
			_thread.Start();
		}
		
		public void Dispose()
		{
			_terminating.Set();
			_thread.Join();
		}
		
		public event EventHandler<MessageEventArgs> OnMessage;
    }
	
    // Example of how to use the Receiver class.
	public class Form1: Form
	{
		MyReceiver _receiver;
		
		public Form1()
		{
            InitializeComponent();
            this.FormClosed += FormClosed;
			_receiver = new MyReceiver();
			_receiver.OnMessage += MessageReceived;
			_receiver.Start();
		}
		public void MessageReceived(object sender, MessageEventArgs e)
		{
            // You need to invoke this, because the event is run on other than the UI thread.
			this.Invoke(new Action(() =>
			{
				listBox1.Items.Add(e.Message);
			});
		}
        public void FormClosed(object sender, EventArgs e)
        {
            _receiver.Dispose();
        }
	}
