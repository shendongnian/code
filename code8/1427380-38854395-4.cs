	public class MyAnotherAwesomeEmailSender : IEmailSender
	{
		public async Task<bool> Send(Email email)
		{
			// send with different way
			return true;
		}
	}
