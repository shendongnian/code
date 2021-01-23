    var json = new WebClient().DownloadString("http://steamcommunity.com/id/tryhardhusky/inventory/json/753/6");
    JObject jo = JObject.Parse(json);
    
    foreach (JProperty x in jo.SelectToken("rgDescriptions"))
    {
    	JToken type = x.Value.SelectToken("type");
    	string typeStr = type.ToString().ToLower();
    
    	if (typeStr.Contains("background"))
    	{
    		Console.WriteLine("Contains 'background'");
    	}
    	if (typeStr.Contains("emoticon"))
    	{
    		Console.WriteLine("Contains 'emoticon'");
    	}
    	if (typeStr.Contains("trading card"))
    	{
    		Console.WriteLine("Contains 'trading card'");
    	}
    }
