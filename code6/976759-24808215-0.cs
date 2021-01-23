    var toRemove = new HashSet<Item>();
    
    foreach (var item in list)
    {
        toRemove.UnionWith(item.GetItemsToRemove());
    }
    
    list.RemoveAll(item => toRemove.Contains(item));
