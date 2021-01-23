    public async Task<T> GetAsync<T>(string uri, string clientId)
        {
			try
			{
             string token = await _tokenProvider.IsTokenNullOrExpired();
			 if (!string.IsNullOrEmpty(token))
                {
                 using (var client = new HttpClient())
                 {
                    ConfigurateHttpClient(client, token, clientId);
                    HttpResponseMessage response = await client.GetAsync(uri);
                    if (response.IsSuccessStatusCode)
                    {
                        return await response.Content.ReadAsAsync<T>();
                    }
                    var exception = new Exception($"Resource server returned an error. StatusCode : {response.StatusCode}");
                    exception.Data.Add("StatusCode", response.StatusCode);
                    throw exception;
                 }
			  }
				else
				{
					var exception = new Exception();
                	exception.Data.Add("StatusCode", HttpStatusCode.Unauthorized);
               		throw exception;
				}
             }
            catch (Exception ex)
            {
                throw;
            }
        }
