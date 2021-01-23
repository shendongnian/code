    Dictionary<int, List<string>> dictionary = new Dictionary<int, List<string>>();
    dictionary.Add(1, new List<string> { "John", "Smith" });
    dictionary.Add(2, new List<string> { "John", "Smith" });
    dictionary.Add(3, new List<string> { "Mike", "Johnson"});
    dictionary.Add(4, new List<string> { "John", "Smith" });
	var result = GetDuplicateKeys(dictionary);
