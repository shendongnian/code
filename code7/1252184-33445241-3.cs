    string x = "AABCDEF";
    List<char> repeatedCharacters = new List<char>();
    x.GroupBy(stringCharacter => stringCharacter)
    .ToList()
    .ForEach(item => {
        if (item.Count() > 1) repeatedCharacters.Add(item.Key);
    });
