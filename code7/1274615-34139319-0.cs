    List<string> lowestList = new List<string>();
    lowestList.AddRange(new[]{"loweststringa", "loweststringb"});
    Dictionary<string, List<string>> innerDictionary = new Dictionary<string, List<string>>();
    innerDictionary.Add("innerstring1", lowestList);
    Dictionary<string, Dictionary<string, List<string>>> myDictionary = new Dictionary<string, Dictionary<string, List<string>>>();
    myDictionary.Add("outerstring", innerDictionary);
