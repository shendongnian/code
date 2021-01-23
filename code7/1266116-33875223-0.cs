    void Main()
    {
    	var s = "{ \"value\" : \"2015-11-23T00:00:00\" }";
    
    	using (var sr = new StringReader(s))
    	using (var jr = new JsonTextReader(sr) { DateParseHandling = DateParseHandling.None })
    	{
    		var j = JToken.ReadFrom(jr);
    		Console.WriteLine(j["value"].ToString()); // prints '2015-11-23T00:00:00'
    	}
    }
