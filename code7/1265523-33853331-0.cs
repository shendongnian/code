	static void Main(string[] args)
	{	
		var json = "{\"my-class\": [{\"class_name\": \"1H\", 
									 \"class_room\": \"201aTD\", 
									 \"day\": \"26\", 
									 \"month\": \"10\", 
									 \"period\": \"2\", 
									 \"subject\": \"IF\", 
									 \"teacher\": \"J04\", 
									 \"year\": \"2015\"}]}";
									 
		Console.WriteLine(JsonConvert.DeserializeObject<RootObject>(json));
	}
	public class RootObject
	{
		[JsonProperty("my-class")]
		public List<MyClass> MyClass { get; set; }
	}
	
	public class MyClass
	{
		[JsonProperty("class_name")]
		public string ClassName { get; set; }
		[JsonProperty("class_room")]
		public string ClassRoom { get; set; }
		[JsonProperty("day")]
		public string Day { get; set; }
		[JsonProperty("month")]
		public string Month { get; set; }
		[JsonProperty("period")]
		public string Period { get; set; }
		[JsonProperty("subject")]
		public string Subject { get; set; }
		[JsonProperty("teacher")]
		public string Teacher { get; set; }
		[JsonProperty("year")]
		public string Year { get; set; }
	}
