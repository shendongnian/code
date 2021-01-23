	public class Model
	{
		public List<Person> Peoples { get; set; }
	}
	
	public class Person
	{
		public Name	Name { get; set; }
		public Fruit Fruit { get; set; }
		public Dimensions Dimensions { get; set; }
	}
	
	public class Name
	{
		public string FirstName { get; set; }	
		public string LastName { get; set; }
	}
	
	public class Fruit
	{
		public string Type { get; set; }	
		public bool Available { get; set; }
	}
	
	public class Dimensions
	{
		public int Length { get; set; }	
		public int Height { get; set; }
		public int Width { get; set; }
	}
