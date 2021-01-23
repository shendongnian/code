	void Main()
	{
		List<Foo> foos = new List<Foo>
		{
			new Foo { Name = "Fu" },
			new Foo { Name = "Foe" },
			new Foo { Name = "Thumb" }
		};
		
		IEnumerable<Bar> bars = foos.Select(foo => new Bar
		{
			BarId = foo.Id,
			Name = foo.Name
		});
		
	}
	
	public class Foo 
	{
		public Foo()
		{
			this.Id = Guid.NewGuid().ToString();
		}
	
		public string Id { get; set; }
		public string Name { get; set; }
	}
	
	public class Bar
	{
		public Bar()
		{
			this.BarId = Guid.NewGuid().ToString();
			this.TimeCreated = DateTime.UtcNow;
		}
	
		public string BarId { get; set; }
		public string Name { get; set; }
		public DateTime TimeCreated { get; set; }
	}
