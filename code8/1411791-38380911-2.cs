    var cache = new Dictionary<string,CarRent>();
    var results = new List<CarRent>();
    for(int i=0;i<myList.Count;i++)
    {
        var curr = myList[i];
        if(cache.ContainsKey(curr.Brand))
        {
             if(curr.Status!="NotActive" && cache[curr.Brand].Status=="Active")
             {
                 results.Add(cache[curr.Brand]);
             }
        }
        cache[curr.Brand]=curr;
    }
    
    
    foreach(var value in cache.Values)
    {
        if(value.Status=="Active")
        {
            results.Add(value);
        }
    }
