    Dictionary<int, Dictionary<String, List<int>>> full_map = new Dictionary<int, Dictionary<String, List<int>>>();
    
    int key = 4;
    if (full_map.ContainsKey(key))
    {
        // the main dictionary has an entry
    
        // temp is the innerdictionary assigned to that key
        var temp = full_map[key];
        
        // add stuff to the inner dictionary
        temp.Add("string key",new List<int>());
    
    }
    else
    {
        // the main dictionary does not have the key
    
        // create an inner dictionary
        var innerDictionary = new Dictionary<string,List<int>>();
        innerDictionary.Add("string key", new List<int>());
        
        // add it to the map with the key
        full_map.Add(key,innerDictionary);
    }
