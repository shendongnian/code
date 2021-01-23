    public string GetJsonReply(string _requestURL)
    {
    	string json = string.Empty;
    	string apiKey = "Foo";
    	string password = "Bar";
    	
    	string credentialsFormatted = string.Format("{0}:{1}",apiKey,password);
    	byte[] credentialBytes = Encoding.ASCII.GetBytes(credentialsFormatted);
    	string basicCredentials = Convert.ToBase64String(credentialBytes);
    	
    	HttpWebRequest request = (HttpWebRequest)WebRequest.Create(_requestURL);
    	request.Method = WebRequestMethods.Http.Get;
    	
    	request.Headers["Authorization"] = "Basic " + basicCredentials;
    	
    	try
    	{
    		using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
    		using (Stream responseStream = response.GetResponseStream())
    		using (StreamReader reader = new StreamReader(responseStream))
    		{
    			json = reader.ReadToEnd();
    		}
    	}
    	catch (Exception e)
    	{
    		json = e.GetBaseException().ToString();
    	}
    
       return json;
    }
