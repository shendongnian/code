    void Main()
    {
    	using (WebClient wc = new WebClient())
        {
        	var json = GetGoogleFromTask(wc);                
    		json.Dump();
        }
    }
    
    public Task<string> GetGoogleFromTask(WebClient wc)
    {
    	string url = "http://www.google.com" ;
        var json = wc.DownloadStringTaskAsync(url);
    	return json;
    }
