	public class Response
	{
	    public string response { get; set; }
		public Dictionary<string, ExampleObj> example { get; set; }
		public string reference { get; set;}
	}
	public class ExampleObj {
		public string ID { get; set; }
		public string Name { get; set; }
	}
	// Somewhere in code
	string jsonString = "{ \"response\": \"success\", \"example\" :{ \"001\":{ \"ID\":\"001\", \"Name\":\"Test1\" }, \"002\":{ \"ID\": \"002\", \"Name\": \"test2\" } }, \"reference\": \"google.com\"}";
	var obj = JsonConvert.DeserializeObject<Response>(jsonString);
	foreach (var keyValuePair in obj.example)
	{
		Console.WriteLine("That's a {0}", keyValuePair.Key);
		Console.WriteLine("It's name is {0}", keyValuePair.Value.Name);
	}
    Console.WriteLine("And, Hey! That's a reference '{0}' and response '{1}'", obj.reference, obj.response);
