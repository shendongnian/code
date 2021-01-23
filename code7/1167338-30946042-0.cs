	private async Task<bool> CheckHostConnectionAsync (string serverName)
		{
			string Message = string.Empty;
			HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(serverName);
			ServicePointManager.ServerCertificateValidationCallback += delegate 
			{
				return true;
			};
			// Set the credentials to the current user account
			request.Credentials = System.Net.CredentialCache.DefaultCredentials;
			request.Method = "GET";
			request.Timeout = 1000 * 40; 
			try
			{
				using (HttpWebResponse response =  (HttpWebResponse) await request.GetResponseAsync ())
				{
					      // Do nothing; we're only testing to see if we can get the response
				}
			}
			catch (WebException ex)
			{
				Message += ((Message.Length > 0) ? "\n" : "") + ex.Message;
				return false;
			}
			if (Message.Length == 0) 
			{
				goToMainActivity (serverName);
			}
			return true; 
		}
