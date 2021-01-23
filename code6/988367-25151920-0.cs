	var t = new Table1() 
	{
		FIELD1 = "Elephant",
		FIELD2 = "Cat",
		FIELD3 = "Dog",
	};
	List<Animal> a = new List<Animal>();
	foreach(var prop in t.GetType().GetProperties().Where(p => p.Name.StartsWith("FIELD")))
	{
		a.Add(new Animal()
		{
			Name = prop.Name,
			Value = (string)prop.GetValue(t)
		});
	}
