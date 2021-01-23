    //just a sample repo : should be persisted, thread safe ...
	public static class MessageRepository
	{
		public static List<Message> UnprocessedMessages = new List<Message>();
		public static void AddMessage(Message msg)
		{
			UnprocessedMessages.Add(msg);
		}
		public static List<Message> GetMessagesByIssuer(string issuer)
		{
			return UnprocessedMessages.Where(m => m.Issuer.Equals(issuer)).ToList();
		}
		public static void Remove(Guid id)
		{
			if (UnprocessedMessages.Any(m => m.messageId.Equals(id)))
			{
				var message = UnprocessedMessages.FirstOrDefault(m => m.messageId.Equals(id));
				UnprocessedMessages.Remove(message);
			}
		}
	}
	[Authorize]
	public class ChatHub : Hub
	{
		public void Send(string who, string data)
		{
			string name = Context.User.Identity.Name;
			List<string> groups = new List<string>();
			groups.Add(name);
			groups.Add(who);
			Message message = new Message()
			{
				messageId = Guid.NewGuid(),
				data = data,
				Issuer = name,
				Receiver = who,
				CreationDate = DateTime.UtcNow
			};
			MessageRepository.AddMessage(message);
			var unProcessedMessages = MessageRepository.GetMessagesByIssuer(name).OrderBy(m => m.CreationDate).ToList();
			unProcessedMessages.ForEach(m =>
			{
				Clients.Groups(groups).addNewMessageToPage(name, JsonConvert.SerializeObject(m));
			});
		}
		public void AcknowledgeServer(Guid messageId)
		{
			// Process the message acknowledge
			var msgGuid = messageId;
			MessageRepository.Remove(msgGuid);
		}
		public override Task OnConnected()
		{
			string name = Context.User.Identity.Name;
			Groups.Add(Context.ConnectionId, name);
			return base.OnConnected();
		}
	}
	public class Message
	{
		public Guid messageId { get; set; }
		public String data { get; set; }
		public String Issuer { get; set; }
		public String Receiver { get; set; }
		public DateTime CreationDate { get; set; }
	}
