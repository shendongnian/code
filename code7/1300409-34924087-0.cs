    using(var client = new HttpClient())
    {
    	//Base Url
    	client.BaseAddress = new Uri("http://secure.logmein.com/public-api/v1/");
    
    	//Add mandatory Request Headers General parameters Section of doc               
    	client.DefaultRequestHeaders.Accept.Clear();
    	client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json");
    	client.DefaultRequestHeaders.Add("Accept", "application/json; charset=utf-8");
    
    	//Authentication header. 
    	string auth = "{\"companyId\":123456,\"psk\":\"ABCZSWDED\"}";
    	client.DefaultRequestHeaders.TryAddWithoutValidation("Authorization:", auth);
    
    	HttpResponseMessage response = client.GetAsync("inventory/hardware/reports").Result;
    }
