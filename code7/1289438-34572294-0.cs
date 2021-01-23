    async Task<Boolean> IsAvailable()
    {
    	string url = "http://www.google.com";
    	try
    	{
    		using (var client = new HttpClient())
    		{
    			HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Head, url);
    			var response = await client.SendAsync(request);
    			if (response.IsSuccessStatusCode)
    			{
    				response.Dump();
    				return true;
    			}
    			else
    			{
    				return false;
    			}
    		}
    	}
    	catch (Exception ex)
    	{
          return false;
    	}
    }
