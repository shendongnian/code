	public partial class ChatWPFClient : Window, IMessageHandler
	{
		... 
		
		public ChatWPFClient()
        {
            InitializeComponent();
            _channelFactory = new DuplexChannelFactory<IChattingService>(new ClientCallback(this), "ChattingServiceEndpoint");
            Server = _channelFactory.CreateChannel();
        }
		
		...
		
		// This is a part of the interface now and needs to be implemented here
		public void TakeMessage(string message, string userName) 
		{
			chatBox.Text += userName + ": " + message + "\n";
		}
	}
