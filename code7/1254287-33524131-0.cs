	public class SmtpEmailGateway : IEmailGateway
	{
		public async Task SendEmailAsync(MailMessage mailMessage)
		{
			using (var smtpClient = new SmtpClient())
			{
				return await smtpClient.SendMailAsync(mailMessage);
			}
		}
	}
	
