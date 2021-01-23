	public static void Main()
	{
		var json = "{\"name\": \"name1\",\"fields\": [{\"id\": \"4786182461\",\"name\": \"field1\",},{\"id\": \"41241241122\",\"name\": \"field2\",}, ]}";
		
		var result = JsonConvert.DeserializeObject<Test>(json);
		
		Console.WriteLine(result.Name);
		Console.WriteLine(result.Count);
	}
	public class Test
	{
		public string Name;
		
		public List<Field> Fields;
	}
	
	public class Field
	{
		public string id;
		public string name;
	}
