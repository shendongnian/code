	_dictionary.Add("Toto", 33);
	_dictionary.Add("Tutu", 22);
	_dictionary.Add("Pouet", 2);
	_dictionary.Add("Pouetr", 57);
	List<KeyValuePair<string, int>> myList = _dictionary.ToList();
	myList.Sort((firstPair, nextPair) => firstPair.Value.CompareTo(nextPair.Value));
	myList.Reverse();
	foreach (KeyValuePair<string, int> keyValuePair in myList)
	{
		Console.Out.WriteLine(keyValuePair.Value + " " + keyValuePair.Key);
	}
