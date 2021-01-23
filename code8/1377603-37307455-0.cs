	public static class email_utility
	{
		public static async Task<bool> send_email(this string body, string subject, string email, int try_count)
		{
			return await Task.Run(() =>
			{
				var cli = new SmtpClient();
				using (var message = new MailMessage(config.sender_email, email))
				{
					message.Subject = subject;
					message.SubjectEncoding = UTF8Encoding.UTF8;
					message.Body = body;
					message.BodyEncoding = UTF8Encoding.UTF8;
					message.DeliveryNotificationOptions = DeliveryNotificationOptions.Never;
					for (var count = 0; count < try_count; ++count)
					{
						try
						{
							lock (config.sender_email)
							{
								cli.Send(message);
								return true;
							}
						}
						catch (SmtpFailedRecipientsException)
						{
							return false;
						}
						catch (SmtpException)
						{
							Thread.Sleep(config.send_timeout);
						}
					}
					return false;
				}
			});
		}
	}
