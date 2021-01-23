    void Main()
    {
    string thejson = @"[{
    	""id"": 6044586,
    	""u"": ""ubergine"",
    	""uid"": ""472505"",
    	""a"": ""2011\/community\/users\/4\/7\/2\/5\/0\/5\/user-472505-originalxoriginal-16-30-27.jpg"",
    	""t"": ""4 weeks ago"",
    	""k"": ""+16"",
    	""p"": ""Prepare to Tri"",
    	""e"": """",
    	""d"": """",
    	""v"": ""unverified"",
    	""gi"": [],
    	""s"": """",
    	""mod"": false,
    	""total"": ""28""
    }, {
    	""id"": 6044596,
    	""u"": ""Fragtaster"",
    	""uid"": ""828120"",
    	""a"": ""2014\/community\/users\/8\/2\/8\/1\/2\/0\/user-828120-originalxoriginal-8-03-00.jpg"",
    	""t"": ""4 weeks ago"",
    	""k"": ""+44"",
    	""p"": ""This [Dark Souls 3] is one of those cases where <strong>\""more of the same\""<\/strong> is a bloody damn good-thing.<br \/>\n<br \/>\n<img src=\""https:\/\/tse2.mm.bing.net\/th?id=OIP.M607bf0698ed2368b9f9cc9e4ea244c77H0&pid=15.1\"" \/>"",
    	""e"": """",
    	""d"": """",
    	""v"": ""unverified"",
    	""gi"": [],
    	""s"": """",
    	""mod"": false,
    	""total"": ""66""
    }]";
    
    	var theobj = JsonConvert.DeserializeObject<List<JsonData>>(thejson);
    	theobj.ForEach(o => o.p.Dump());
    }
    
    // Define other methods and classes here
    public class JsonData
    {
    	public string id { get; set; }
    	public string u { get; set; }
    	public string uid { get; set; }
    	public string a { get; set; }
    	public string t { get; set; }
    	public string k { get; set; }
    	public string p { get; set; }
    	public string e { get; set; }
    	public string d { get; set; }
    	public string v { get; set; }
    	public string[] gi { get; set; }
    	public string s { get; set; }
    	public string mod { get; set; }
    	public string total { get; set; }
    }
