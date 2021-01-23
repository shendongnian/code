    var results = str.Select(x => {
		foreach (string word in stop_word)
		{
			x = x.ToLower().Replace(word, "").Trim();
		}
		return x;
	}).ToList(); // You can use ToArray() if you wish too.
    ...
    foreach(string result in results)
	{
		Console.WriteLine(result);
	}
