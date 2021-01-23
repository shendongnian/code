    Dictionary<string, int> testDict = new Dictionary<string, int>();
    testDict.Add("one", 1);
    testDict.Add("two", 2);
    testDict.Add("three", 3);
    		
    testDict.ToList<KeyValuePair<string, int>>().ForEach(x => Console.WriteLine(x.Key));
