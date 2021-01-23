    private readonly SortedDictionary<string, int> sortedDictionary = CreatePathCollection(path, entityKey); 
    
    public void Set(string path, int index)
    {
        sortedDictionary.Remove(path);
        var i = 91;
        foreach (var key in sortedDictionary.Keys)
            sortedDictionary[key] = i++;
        sortedDictionary[path] = index;
    }
