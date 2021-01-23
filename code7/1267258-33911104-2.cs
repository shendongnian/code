	[CallbackBehavior(ConcurrencyMode = ConcurrencyMode.Multiple)]
	public class ClientCallback : IClient
	{
		private IMessageHandler messageHandler;
		
		public ClientCallBack(IMessageHandler messageHandler)
		{
			this.messageHandler = messageHandler;
		}
		
		public void GetMessage(string message, string userName)
		{
			messageHandler.TakeMessage(message, userName);
		}
	} 
