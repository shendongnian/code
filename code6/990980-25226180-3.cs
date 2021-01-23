	private static async Task SubmitUrlAsync(string url)
	{
		try
		{
			var httpClient = new HttpClient();
			Logger.Log(string.Format("Start Invoking URL: {0}", url));
			await httpClient.GetAsync(url);
			
			Logger.Log(string.Format("End Invoking URL: {0}", url));
		}
		catch (WebException ex)
		{
			if (ex.Status != WebExceptionStatus.Timeout)
			{
				Logger.Log(string.Format("Exception Invoking URL: 
									{0} \n {1}", url, ex.ToString()));
				throw;
			}
		}
		catch (Exception ex)
		{
			Logger.Log(string.Format("Exception Invoking URL: 
								{0} \n {1}", url, ex.ToString()));
			throw;
		}
	}
