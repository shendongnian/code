    Dictionary<string, int> counter = new Dictionary<string, int>();
    foreach(var item in items)
    {
        if(counter.ContainsKey(item))
        {
            counter[item] = counter[item] + 1;
        }
    }
