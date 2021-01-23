	public interface IMessageService
	{
		void Send(string subject, string body);
		bool AppliesTo(IEnumerable<string> providers);
	}
	public class EmailMessageService : IMessageService
	{
		public EmailMessageService(/* inject dependencies (and configuration) here */)
		{
			// Set dependencies to private (class level) variables
		}
		
		public void Send(string subject, string body)
		{
			// Implementation - use dependencies as appropriate
		}
		
		public bool AppliesTo(IEnumerable<string> providers)
		{
			return providers.Contains("email");
		}
	}
	public class SmsMessageService : IMessageService
	{
		public SmsMessageService(/* inject dependencies (and configuration) here */)
		{
			// Set dependencies to private (class level) variables
		}
		
		public void Send(string subject, string body)
		{
			// Implementation - use dependencies as appropriate
		}
		
		public bool AppliesTo(IEnumerable<string> providers)
		{
			return providers.Contains("sms");
		}
	}
