    var items = new List<int> { 1, 2, 3, 2, 3 };
    var itemsDictionary = new Dictionary<int, List<string>>();
    
    foreach (int i in items)
    {
        List<string> repeatedValues;
        if(itemsDictionary.TryGetValue(i, out repeatedValues))
        {
            repeatedValues.Add(i.ToString());
        }
        else
        {
            itemsDictionary.Add(i, new List<string> { i.ToString() });
        }
    }
    
    foreach (KeyValuePair<int, List<string>> kvp in itemsDictionary)
    {
        //do whatever is needed kvp.Value
    
    }
