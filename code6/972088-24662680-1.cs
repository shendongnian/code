	public class Parent
	{
		public int ID { get; set; }
		
		public List<Child> Children { get; set; }
	}
	
	public class Child
	{
		public int ID { get; set; }
		public string Name { get; set; }
	}
