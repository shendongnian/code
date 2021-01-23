	void Main()
	{
		var root = JsonConvert.DeserializeObject<RootObject>(json);
		var selectedTravel = root.Travels.FirstOrDefault(x => x.Id == 2);
	}
	public class Travel
	{
		[JsonProperty("date")]
		public DateTime Date { get; set; }
		[JsonProperty("id")]
		public int Id { get; set; }
	}
	
	public class RootObject
	{
		public List<Travel> Travels { get; set; }
	}
