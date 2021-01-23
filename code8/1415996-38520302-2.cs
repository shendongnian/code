    // initialize alist of entities (User)
	var entities = new List<User>();
	entities.Add(new User { Name = "First", Type = "TypeA", SomeOtherField="abc" });
	entities.Add(new User { Name = "Second", Type = "TypeB", SomeOtherField = "xyz" });
	
	// set the wanted fields
	string[] columns = { "Name", "Type" };
	
	// create a set of properties of the User class by the set of wanted fields
	var properties = typeof(User).GetProperties()
							.Where(p => columns.Contains(p.Name))
							.ToList();
	
	// Get it with a single select (by use of the Dynamic object)
	var selectResult = entities.Select(e =>
	{
		dynamic x = new ExpandoObject();
		var temp = x as IDictionary<string, Object>;
		foreach (var property in properties)
			temp.Add(property.Name, property.GetValue(e));
		return x;
	});
	
	// itterate the results
	foreach (var result in selectResult)
	{
		Console.WriteLine(result.Name);
		Console.WriteLine(result.Type);
	}
