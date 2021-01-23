    int i = 4;
    Dictionary<int, List<string>> res = new Dictionary<int, List<string>>();
    foreach (var item in dict)
    {
        int takeItems = i - res.Values.SelectMany(r => r).Count();
        if (takeItems > 0)
        {
            res.Add(item.Key, item.Value.Take(takeItems).ToList());
        }
        else
        {
            break;
        } 
    }
