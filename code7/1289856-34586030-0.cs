    void Main()
    {
    	string jsonText =
    @"{
    	""data"": [
    	{
      ""installed"": true,
    	  ""id"": ""1292282928282""
    },
    {
    	""installed"": true,
      ""id"": ""29282829292""
    }
    ],
    ""paging"": {
    	""next"": ""https://graph.facebook.com/v2.5/105157539862931/friends?fields=installed&format=json&access_token=CAALVPHznNpcBAOnO94HvqUgYKI2kObPZBgR0sqIOMSRO9swZBBTWHb6FjliZCT1KyCmPbnX42xvtngboh3DjFOrixw0pSenwRZA1oXZAHNDdYcGsHNOHjQcZB0f6fsZBQJjhOTttwQu7E5hZBDcAWJVZBGK2AxrZBDZBxLL7I5pjXwwbb12hDytZAiVzUmNzi1Ae2CCvOnL6QCpqzsJT7fWWjXXi&limit=25&offset=25&__after_id=enc_AdB7PJbXYkDSSZAq33AjPXZAeRnlrZBDwjAAILZAg3emHdei0qdRLa2AeD6sRuX6h0OQuPQi8x8bvSHPy0EqIgybYL89""
    },
    ""summary"": {
    	""total_count"": 2
    }
    }";
    
     var x = JsonConvert.DeserializeObject<Response>(jsonText);
     //To Get installed
     x.data.Select(d => d.installed).Dump();
    }
    
    public class Response
    { 
        public Data[] data;
    	public Paging paging;
    	public Summary summary;
    }
    
    public class Data
    {
    	public bool installed { get; set; }
    	public string id { get; set; }
    }
    
    public class Paging
    {
    	public string next { get; set; }
    }
    
    public class Summary
    {
    	public int total_count { get; set;}
    }
