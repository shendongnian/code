	public class Rootobject
	{
		[JsonProperty("page")]
		public Page page { get; set; }
	}
	public class Page
	{
		[JsonProperty("results")]
		public Result[] results { get; set; }
		[JsonProperty("start")]
		public int start { get; set; }
		[JsonProperty("limit")]
		public int limit { get; set; }
		[JsonProperty("size")]
		public int size { get; set; }
	}
	public class Result
	{
		[JsonProperty("id")]
		public string id { get; set; }
		[JsonProperty("type")]
		public string type { get; set; }
		[JsonProperty("status")]
		public string status { get; set; }
		[JsonProperty("title")]
		public string title { get; set; }
	}
