    var w = words.SelectMany(x => x.Distinct()).ToList(); //Add this line to get all the words in an array
    // OR Use Dictionary
    var dic = new Dictionary<string, int>();
	foreach(var item in words)
	{
		dic.Add(item.Key, item.Count());
	}
    
