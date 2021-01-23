    var kvpList = new List<KeyValuePair<string, string>>
    {
    	new KeyValuePair<string, string>("", "yo! r u dtf?")
    };
    FormUrlEncodedContent rqstBody = new FormUrlEncodedContent(kvpList);
    
    
    string baseUrl = "http://localhost:60123"; //or "http://SERVERNAME/AppName"
    string C_URL_API = baseUrl + "/api/values";
    using (var httpClient = new HttpClient())
    {
    	try
    	{   
    		HttpResponseMessage resp = await httpClient.PostAsync(C_URL_API, rqstBody); //rqstBody is HttpContent
    		if (resp != null && resp.Content != null) {
    			var result = await resp.Content.ReadAsStringAsync();
                //do whatevs with result
    		} else
    			//nothing returned.
    	}
    	catch (Exception ex)
    	{
    		Console.ForegroundColor = ConsoleColor.Red;
    		Console.WriteLine(ex.Message);
    		Console.ResetColor();
    	}
    }
