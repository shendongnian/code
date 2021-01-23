	public static class Progress
	{
		public static void Notify(string processID, string message, float value)
		{
			IHubContext context = GlobalHost.ConnectionManager.GetHubContext<ProgressHub>();
			context.Clients.Group(processID).updateProgress(message, value);
		}
	}
