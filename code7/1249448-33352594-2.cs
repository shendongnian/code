	var list = new List<int>();
	list.Add(5);
	list.Add(1);
	list.Add(59);
	list.Add(4);
    list.Sort();
	foreach (var element in list)
	{
		Console.WriteLine(element);  // Outputs 1, 4, 5, 59
	}
