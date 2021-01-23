    public static async Task<byte[]> GetPostContentAsync(string url, string data)
    {
    	var content = new MemoryStream();
    	var cookies = new CookieContainer();
    
    	HttpWebRequest webReq;
    
    	webReq = (HttpWebRequest)WebRequest.Create(url);
    
    	webReq.CookieContainer = cookies;
    	webReq.Method = "POST";
    	webReq.ContentType = "application/x-www-form-urlencoded";
    
    	Stream requestStream = await webReq.GetRequestStreamAsync();
    
    	using (var writer = new StreamWriter(requestStream))
    	{
    		await writer.WriteAsync(data);
    	}
    
    	using (var responseStream = await webReq.GetResponseAsync())
    	{
    		using (Stream response = responseStream.GetResponseStream())
    		{
    			await response.CopyToAsync(content);
    		}
    	}
    
    	return content.ToArray();
    }
