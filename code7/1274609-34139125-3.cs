    Dictionary<string, Dictionary<string, List<string>>> myDictionary = new Dictionary<string, Dictionary<string, List<string>>>();
    if (!myDictionary.ContainsKey("outerKey"))
    {
       
        myDictionary.Add("outerKey",  new Dictionary<string, List<string>>());
    }
