    var outerKey = "Some Outer Key";
    var innerKey = "Some Inner Key";
    var myValue = "Some Value";
    
    if (!myDictionary.ContainsKey(outerKey))
    {
        myDictionary.Add(outerKey, new Dictionary<string, List<string>>());
    }
    
    if (!myDictionary[outerKey].ContainsKey(innerKey))
    {
        myDictionary[outerKey].Add(innerKey, new List<string>());
    }
    
    myDictionary[outerKey][innerKey].Add(myValue);
