	public static object GetProperty(IDictionary<string, object> dict, string path)
	{
		string[] split = path.Split('.');
		object obj = dict[split[0]];
		var type = obj.GetType();
		return type.InvokeMember(split[1], BindingFlags.Public | BindingFlags.Instance | BindingFlags.GetField | BindingFlags.GetProperty, null, obj, null);
	}
 
	var dict = new Dictionary<string, object>();
	var cl = new MyClass();
	dict["obj"] = cl;
	cl.X = "1";
	cl.Y = "2";
	Console.WriteLine(GetProperty(dict, "obj.X"));
	Console.WriteLine(GetProperty(dict, "obj.Y"));
