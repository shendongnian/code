    using (HttpClient client = new HttpClient())
    {
    	using (HttpResponseMessage response = await client.GetAsync(page))
        {
    	    using (HttpContent content = response.Content)
    	    {
    	        string contentString = await content.ReadAsStringAsync();
    var myParsedObject = (MyObject)(new JavaScriptSerializer()).Deserialize(contentString ,typeof(MyObject));
    	    }
    
        }
    }
