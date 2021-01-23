	public void DeserializeFoo()
	{
		var json = "[{\"id\":\"111\",\"name\":\"Robocop\",\"cover\":\"3114188e.jpg\"},
					 {\"id\":\"222\",\"name\":\"Eater\",\"cover\":\"72dpi.jpg\"}]";
					 
		var foos = JsonConvert.DeserializeObject<List<Foo>>(json);
		foreach (var foo in foos)
		{
			Console.WriteLine("Id: {0}", foo.Id);
			Console.WriteLine("Name: {0}", foo.Name);
			Console.WriteLine("Cover: {0}", foo.Cover);
		}
	}
	
	public class Foo
	{
		[JsonProperty("id")]
		public string Id { get; set; }
		[JsonProperty("name")]
		public string Name { get; set; }
		[JsonProperty("cover")]
		public string Cover { get; set; }
	}
