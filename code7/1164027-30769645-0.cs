	public void getMembersInfo()
	{
		Dictionary<String, String> dict = new Dictionary<string, string>();
		dict.Add("name", "Name Test");
		dict.Add("address", "Addss Test");
	
		Members test = DeserializeObject<Members>(dict);
		Console.WriteLine("Var Name: " + test.name);
	}
	
	//Really "value" is a string type, but with "Dictionary" is more easy simulate the problem.
	public static T DeserializeObject<T>(Dictionary<string, string> value)
	{
		var type = typeof(T);
		var TheClass = (T)Activator.CreateInstance(type);
		foreach (var item in value)
		{
			type.GetField(item.Key).SetValue(TheClass, item.Value);
		}
		return (T)TheClass;
	}
	
	public class Members
	{
		public String name;
		public int age;
		public String address;
	}
