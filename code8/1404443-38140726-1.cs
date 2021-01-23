    //POST
    var httpWebRequest = (HttpWebRequest)WebRequest.Create("path/api");
    httpWebRequest.ContentType = "text/json";
    httpWebRequest.Method = WebRequestMethods.Http.Post;
    httpWebRequest.Accept = "application/json; charset=utf-8";
    //probably have to be added
    //httpWebRequest.ContentLength = json.Length;
    
    //do request
    using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
    {
    	//write post data
    	//also you can serialize yours objects by JavaScriptSerializer
    	streamWriter.Write(json);
    	streamWriter.Flush();
    }
    
    //get responce
    using (var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse())
    {
    	//read
    	using (Stream stream = httpResponse.GetResponseStream())
    	{
    		using (StreamReader re = new StreamReader(stream))
    		{
    			String jsonResponce = re.ReadToEnd();
    		}
    	}
    }
    
    //GET
    var httpWebRequest = (HttpWebRequest)WebRequest.Create("path/api");
    httpWebRequest.ContentType = "text/json";
    httpWebRequest.Method = WebRequestMethods.Http.Get;
    httpWebRequest.Accept = "application/json; charset=utf-8";
    
    //get responce
    using (var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse())
    {
    	//read
    	using (Stream stream = httpResponse.GetResponseStream())
    	{
    		using (StreamReader re = new StreamReader(stream))
    		{
    			String jsonResponce = re.ReadToEnd();
    		}
    	}
    }
