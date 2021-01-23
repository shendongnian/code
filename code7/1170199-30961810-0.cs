    /// <summary>
	/// Global class used to set the status message
	/// </summary>
	public static class StatusSetter
	{
		public static void SetStatus(string s)
		{
			Messenger.Default.Send(new StatusMessage(s));
		}
	}
	/// <summary>
	/// Holds the status message.
	/// </summary>
	public class StatusMessage
	{
		public StatusMessage(string status)
		{
			NewStatus = status;
		}
		public string NewStatus { get; set; }
	}
