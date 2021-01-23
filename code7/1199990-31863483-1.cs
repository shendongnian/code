    var charDictionary = new Dictionary<char, int>();
    string sign = "attitude";
    foreach(char currentChar in sign)
    {
        if(charDictionary.ContainsKey(currentChar))
        { charDictionary[currentChar]++; }
        else
        { charDictionary.Add(currentChar, 1); }
    }
