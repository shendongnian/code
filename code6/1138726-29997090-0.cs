    void Send(string email, string subject, string body)
		{
			SmtpClient client = new SmtpClient(_Host, _Port);
			client.Timeout = _Timeout;
			client.EnableSsl = _Ssl;
			client.DeliveryMethod = SmtpDeliveryMethod.Network;
			client.UseDefaultCredentials = false;
			client.Credentials = new System.Net.NetworkCredential(_Username, _Password);
			MailMessage message = new MailMessage("No Reply <noreply@mysite.com>", email, subject, body);
			message.BodyEncoding = UTF8Encoding.UTF8;
			message.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
			message.Sender = new MailAddress("noreply@mysite.com", "No Reply");
			lock (this)
			{
				for (var count = 0; count < _MaxTryCount; ++count)
				{
					try
					{
						client.Send(message);
						return;
					}
					catch (SmtpFailedRecipientsException)
					{
						return;
					}
					catch (SmtpException)
					{
						Thread.Sleep(_Timeout);
					}
					catch (Exception)
					{
						return;
					}
				}
			}
		}
