    string x = "AABCDEF";
    List<char> repeatedCharacters = new List<char>();
    var groupsOfChars = x.GroupBy(stringCharacter => stringCharacter);
    groupsOfChars.ToList().ForEach(item => {
        if (item.Count() > 1) repeatedCharacters.Add(item.Key);
    });
