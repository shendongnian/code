     public async Task<HttpResponseMessage> Post()
    {
    	HttpResponseMessage response;
    	
    		//Check if post is MultiPart
    		if (!Request.Content.IsMimeMultipartContent())
    		{
    			throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
    		}
    
    		string root = HttpContext.Current.Server.MapPath("~/App_Data");
    		var provider = new MultipartFormDataStreamProvider(root);
    
    		//This right the file in your App_Data
    		await Request.Content.ReadAsMultipartAsync(provider);
    
    		foreach (MultipartFileData file in provider.FileData)
    		{
    			//Here you can get the full file path on the server                  
    			tempFileName = file.LocalFileName;
    		}
    
    		// You values are inside FormData. You can access them in this way
    		foreach (var key in provider.FormData.AllKeys)
    		{
    			foreach (var val in provider.FormData.GetValues(key))
    			{
    				Trace.WriteLine(string.Format("{0}: {1}", key, val));
    			}
    		}
    		
    		//Or directly (not safe)
    
    		string name = provider.FormData.GetValues("name").FirstOrDefault();
    		
    		response = Request.CreateResponse(HttpStatusCode.Ok);              
    
    	return response;
    }
