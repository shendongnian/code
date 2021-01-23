    public async void GetUsers()
		{
			// Get OAuth token using client credentials 
			string tenantName = "your-tenant-name.onmicrosoft.com";
			string authString = "https://login.microsoftonline.com/" + tenantName;
			AuthenticationContext authenticationContext = new AuthenticationContext(authString, false);
			// Config for OAuth client credentials  
			string clientId = "your-client-id";
			string key = "your-AzureAD-App-Key";
			ClientCredential clientCred = new ClientCredential(clientId, key);
			string resource = "https://graph.windows.net";
			AuthenticationResult authenticationResult;
			try
			{
				authenticationResult = await authenticationContext.AcquireTokenAsync(resource, clientCred);
			}
			catch(Exception ex)
			{
				throw new Exception(ex.Message, ex.InnerException);
			}
			var client = new HttpClient();
			var request = new HttpRequestMessage(System.Net.Http.HttpMethod.Get, "https://graph.windows.net/your-tenant-name.onmicrosoft.com/users?api-version=1.6");
			request.Headers.Authorization =
			  new AuthenticationHeaderValue("Bearer", authenticationResult.AccessToken);
			var response = await client.SendAsync(request);
			var content = await response.Content.ReadAsStringAsync();
		}
