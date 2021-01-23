	public class JokeInfo
	{
		[JsonProperty("id")]
		public int Id { get; set; }
		[JsonProperty("joke")]
		public string Joke { get; set; }
		[JsonProperty("categories")]
		public IList<string> Categories { get; set; }
	}
	public class ServerResponse
	{
		[JsonProperty("type")]
		public string Type { get; set; }
		[JsonProperty("value")]
		public JokeInfo JokeInfo { get; set; }
	}
	
