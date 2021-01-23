	string str =  Console.ReadLine().ToLower();
	string sortedString = String.Concat(str.OrderBy(c => c));
	var result = sortedString.GroupBy(x => x).Select(y => string.Format("{0} => {1}", y.Key, y.Count())).ToList();
	foreach (var output in result)
	{
		Console.WriteLine(output);
	}
