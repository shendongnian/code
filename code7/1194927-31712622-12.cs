    public abstract class BaseHttpServiceClient<TEntity, TPrimaryKey> where TEntity : class
	{
		private string remoteUri;
		protected BaseHttpServiceClient(string remoteUri) { this.remoteUri = remoteUri; }
		protected virtual TEntity GetRemoteItem(TPrimaryKey id)
		{
            TEntity testData = null;
            try
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    string requestUri = this.remoteUri + id.ToString();
                    HttpRequestMessage testRequest = new HttpRequestMessage(HttpMethod.Get, requestUri);
                    HttpResponseMessage response = httpClient.SendAsync(testRequest).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        var jsonData = response.Content.ReadAsStringAsync().Result;
                        testData = JsonConvert.DeserializeObject<TEntity>(jsonData);
                    }
                }
            }
            catch (Exception ex)
            {           
            }
            return testData;
		}
	}
