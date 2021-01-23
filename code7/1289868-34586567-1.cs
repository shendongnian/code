    IEnumerable<int> collection = ctx.table;
    if(list1.Count > 0)
    {
        collection = collection.Where(o => list1.Contains(o.item1));
    }
    if(list2.Count > 0)
    {
        collection = collection.Where(o => list2.Contains(o.item2));
    }
    if(list3.Count > 0)
    {
        collection = collection.Where(o => list3.Contains(o.item3));
    }
