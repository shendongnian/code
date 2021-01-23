	void Main()
	{
		var travels = JsonConvert.DeserializeObject<List<Travel>>(json);
		var selectedTravel = travels.FirstOrDefault(x => x.Id == "2");
	}
	public class Travel
	{
		[JsonProperty("date")]
		public string Date { get; set; }
		[JsonProperty("id")]
		public int Id { get; set; }
	}
