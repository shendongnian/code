    public static async string GetWebData(string url)
    {
    	using (var webClient = new WebClient())
    	{
    		return await webClient.DownloadStringTaskAsync(new Uri(url));
    	}
    }
    
    public static async SyndicationFeed ProcessWebData(string data)
    {
    	using (XmlTextReader reader = new XmlTextReader(new StringReader(response)))
    	{
    		return SyndicationFeed.Load(reader);
    	}
    }
