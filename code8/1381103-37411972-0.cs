    List<string> testKeys = new List<string>();
    foreach (var pairs in dict)
    {
        if (pair.Value == "TEST")
        {
            testKeys.Add(pair.Key);
        }
    }
