    string getResponse(WebRequest request, out exceptionOccured)
    {
    	exceptionOccured = false;
    	try
    	{
    		HttpWebResponse resp = (HttpWebResponse)request.GetResponse();
    		var stream = resp.GetResponseStream();
    		using (var reader = new StreamReader(stream))
    		{
    			return reader.ReadToEnd();
    		}
    	}
    	catch (WebException ex)
    	{
    		exceptionOccured = true;
    		using (var stream = ex.Response.GetResponseStream())
    		{
    			using (var reader = new StreamReader(stream))
    			{
    				return reader.ReadToEnd();
    			}
    		}
    	}
    	catch (Exception ex)
    	{
    		exceptionOccured = true;
    		// Something more serious happened
    		// like for example you don't have network access
    		// we cannot talk about a server exception here as
    		// the server probably was never reached
    		return ex.Message;
    	}
    }
