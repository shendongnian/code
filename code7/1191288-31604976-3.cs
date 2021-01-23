    foreach (var g in groupedItems)
    {
        Dictionary<string, string> newItem = new Dictionary<string, string>();
        foreach(var item in g) 
        {
            newItem.Add("name", item.Name);
            newItem.Add("value", item.Value);    
        }
        if (!items.Contains(newItem, new EqualityComparer()) items.Add(newItem);
    }
