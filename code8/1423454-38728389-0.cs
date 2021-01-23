    Dictionary<string, string> myDict = new Dictionary<string, string>();
    myDict.Add("a", "1");
    myDict.Add("aa", "1");
    myDict.Add("c", "3");
    
    string result;
    if (myDict.TryGetValue("a", out result)){
       //do something with result
    }
    
