	var lists = new ListOfVariablesToSave();
	foreach (var list in lists) 
	{
		Console.WriteLine(list.Name);
		foreach (var i in list)
		{
			Console.WriteLine(i);
		}
	}
