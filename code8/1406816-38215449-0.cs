	public class MyClass
	{
		[Key]
		public uint MyObjectId { get; set; }
		public long Param1 { get; set; }
		public string Param2 { get; set; }
	}
	
	void Main()
	{
		var properties = typeof(MyClass).GetProperties()
		  .Where(prop => prop.IsDefined(typeof(KeyAttribute), false));
	}
