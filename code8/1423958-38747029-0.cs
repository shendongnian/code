    public class Location
	{
		public string Name { get; set; }
		public string Address { get; set; }
		public string City { get; set; }
		public string State { get; set; }
		public string Zip { get; set; }
	}
	public class AK
	{
		public Location[] Anchorage { get; set; }
		public Location[] Fairbanks { get; set; }
	}	
	
	
	var ak = JsonConvert.DeserializeObject<AK>(json);
