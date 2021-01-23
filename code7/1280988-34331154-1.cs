	public interface IMessageStrategy
	{
		void Send(string message, string body, string provider);
		void Send(string message, string body, IEnumerable<string> providers);
	}
	public class MessageStrategy : IMessageStrategy
	{
		private readonly IMessageService[] messageServices;
		public MessageStrategy(IMessageService[] messageServices)
		{
			if (messageServices == null)
				throw new ArgumentNullException("messageServices");
			this.messageServices = messageServices;
		}
		
		public void Send(string message, string body, string provider)
		{
			string[] providers = provider.Split(';').Select(p => p.ToLower().Trim()).ToArray();
			this.Send(message, body, providers);
		}
		
		public void Send(string message, string body, IEnumerable<string> providers)
		{
			foreach (IMessageService messageService in messageServices)
			{
				if (messageService.AppliesTo(providers))
				{
					messageService.Send(message, body);
				}
			}
		}
	}
