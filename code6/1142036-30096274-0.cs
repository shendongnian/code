    public string CallRequest(Uri url)
    {
    	var request = WebRequest.Create(url) as HttpWebRequest;
    	var httpResponse = "";
    	if (request != null)
    	{
    		request.UserAgent = "stackoverflow"; // just example.
    		request.Accept = "gzip,deflate";
    		request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
    	
    		using (var response = request.GetResponse() as HttpWebResponse)
    		{			
    			using (var responseStream = response.GetResponseStream())
    			{
    				var reader = new StreamReader(responseStream);
    				httpResponse = reader.ReadToEnd();
    			}
    		}
    	}
    	
    	return httpResponse;
    }   
