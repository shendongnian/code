        protected bool NotifyByMail(string server, string strFrom, string strTo, string strSubject, string strBodyText, bool isBodyTextHtml = false)
		{
			if (string.IsNullOrEmpty (server)
				|| string.IsNullOrEmpty (strFrom)
				|| string.IsNullOrEmpty (strTo)
				|| string.IsNullOrEmpty (strSubject)
				|| string.IsNullOrEmpty (strBodyText))
				return false;
			try {
				MailAddress from = new MailAddress (strFrom);
				MailAddress to = new MailAddress (strTo);
				MailMessage message = new MailMessage (from, to);
				message.Subject = strSubject;
				message.Body = strBodyText;
                message.IsBodyHtml = isBodyTextHtml;
				SmtpClient client = new SmtpClient (server);
            // Include credentials if the server requires them.
            //client.Credentials = new System.Net.NetworkCredential ("********", "*******");// System.Net.CredentialCache.DefaultNetworkCredentials;
				client.Send (message);
                return true;
			}
			catch (Exception exception) {
                        // TODO ErrorHandling
			}
			return false;
		}
 
