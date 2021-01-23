	public class ExternalClass
	{
		public event MessageReceivedHandler MessageReceived;
		public void Send(MyMessage message)
		{
			this.MessageReceived(new MyMessage()
			{
				Address = message.Address,
				Data = message.Data + "!"
			});
		}
	}
