    var cache = new Dictionary<string,List<CarRent>>();
    for(int i=0;i<myList.Count;i++)
    {
        var curr = myList[i];
        if(!cache.ContainsKey(curr.Brand))
        {
            cache[curr.Brand]=new List<CarRent>();
        }
        if(curr.Status == "InActive")
            cache[curr.Brand].Clear();
        else if(curr.Status == "Active")
            cache[curr.Brand].Add(curr);
    }
    
    var results = cache.Values.SelectMany(a=>a);
