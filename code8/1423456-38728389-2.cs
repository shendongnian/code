    Dictionary<string, int> myDict = new Dictionary<string, int>();
    myDict.Add("a", 1);
    myDict.Add("aa", 1);
    myDict.Add("c", 3);
    
    int result;
    if (myDict.TryGetValue("a", out result)){
       //do something with result
    }
    
