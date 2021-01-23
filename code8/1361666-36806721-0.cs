    List<string> keys= new List<string>();
    foreach(var item in Dates)
    {
        if (item.Key.Contains("2016/4/")
            keys.Add(item.Key);
    }
