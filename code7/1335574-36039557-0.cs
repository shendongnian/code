    if (s != null && fivewordDictionary.ContainsKey(s))
    {
        Console.WriteLine(userWord + ": " + fivewordDictionary[s]);
    }
    else
    {
        Console.WriteLine(userWord + ": not found!");
    }
