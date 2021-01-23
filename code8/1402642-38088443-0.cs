    try
    {
    	using (WebClient wc = new WebClient()) 
    	{
    		string url = currentURL + "resources?AUTHTOKEN=" + pmtoken;
    		var json = await wc.DownloadStringTaskAsync(url);
    		resourcesinfo = JsonConvert.DeserializeObject<ResourcesInfo>(json);
    	}
    
    	object syncObj = new object();  // create sync object
    	Parallel.ForEach(resourcesinfo.operation.Details, new ParallelOptions { MaxDegreeOfParallelism = 7 }, (c) =>
    	{
    		ResourceAccountListInfo resourceAccountListInfo = new ResourceAccountListInfo();
    		using (WebClient wc = new WebClient()) 
    		{
    			string url = currentURL + "resources/" + c.RESOURCEID + "/accounts?AUTHTOKEN=" + pmtoken;
    			string tempurl = url.Trim();
    
    			var json =  wc.DownloadString(tempurl);
    			resourceAccountListInfo = JsonConvert.DeserializeObject<ResourceAccountListInfo>(json);
    		}
    
    		lock(syncObj)  // lock using sync object
    		{
    			PMresourcesOnly.Add(resourceAccountListInfo.operation.Details);
    		}
    	});//end of foreach
    
    	return PMresourcesOnly.ToList();
    }
    catch (Exception e)
    {
    }
