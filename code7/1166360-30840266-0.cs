    Item[] items; 
    lock (myListLock)
    {
        items = _items.ToArray();
    }
    foreach (var item in items)
    {
        var dp = item.DataPoint;
    }
