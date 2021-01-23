	if (test is IDictionary)
	{
		var list = GetListFromDictionary(test);
		if (list != null)
		{
			Console.WriteLine(list[1]);
			Console.WriteLine(list.IndexOf(new KeyValuePair<int, string>(2,"2")));
		}
	}
