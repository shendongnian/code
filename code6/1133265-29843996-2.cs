    public class PresenceMonitor
	{
		private Timer _timer;
		// How often we plan to check if the connections in our store are valid
		private readonly TimeSpan _presenceCheckInterval = TimeSpan.FromSeconds(10);
		public PresenceMonitor()
		{
		}
		public void StartMonitoring()
		{
			if (_timer == null)
			{
				_timer = new Timer(_ =>
				{
					try
					{
						Check();
					}
					catch (Exception ex)
					{
						// Don't throw on background threads, it'll kill the entire process
						Trace.TraceError(ex.Message);
					}
				},
				null,
				TimeSpan.Zero,
				_presenceCheckInterval);
			}
		}
		private void Check()
		{
			var context = GlobalHost.ConnectionManager.GetHubContext<ChatHub>();
			var messages = MessageRepository.GetAllMessages();
			messages.ForEach(m =>
			{
				if (context != null)
				{
					List<string> groups = new List<string>();
					groups.Add(m.Issuer);
					groups.Add(m.Receiver);
					context.Clients.Groups(groups).addNewMessageToPage(m.Issuer, JsonConvert.SerializeObject(m));
				}
			});
			
		}
	}
