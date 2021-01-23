    public class KeywordTitle
    {
        public string keyword { get; set; }
        public string title { get; set; }
    }
    public class Response
    {
        public string error { get; set; }
        public string message { get; set; }
        public Dictionary<string, object> data { get; set; }
    }
    var dictionary = new Dictionary<string, object> {
        {"version", "sring"}
    };
	dictionary.Add("1", new []
	{
		new KeywordTitle { keyword = "", title = "" },
		new KeywordTitle { keyword = "", title = "" },
		new KeywordTitle { keyword = "", title = "" }
	});
	JsonConvert.SerializeObject(new Response
	{
		error = "0",
		message = "messages",
		data = dictionary
	});
