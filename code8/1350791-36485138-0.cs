	void Main()
	{
		var t = typeof(DemoClass);
		var typeTree = GetTypeTree(t);
		List<PropertyInfo> info = typeof(DemoClass)
			.GetProperties(BindingFlags.Public | BindingFlags.Instance)
			.OrderByDescending(x => typeTree.IndexOf(x.DeclaringType))
			.ThenBy(GetOrderNumber).ToList();
		
		foreach (var prop in info)
			Console.WriteLine(prop.Name);
	}
	int? GetOrderNumber(PropertyInfo prop) {
		var attr = (TestAttribute)prop.GetCustomAttributes(typeof(TestAttribute), true)
                         .FirstOrDefault();
		if (attr != null)
			return attr.order;
		else
			return null;
	}
	
	IList<Type> GetTypeTree(Type t) {
		var types = new List<Type>();
		while (t.BaseType != null) {
			types.Add(t);
			t = t.BaseType;
		}
		return types;
	}
