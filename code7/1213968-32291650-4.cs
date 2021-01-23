    static void DFS(Item item, List<Item> component)
    {
        if (component.Contains(item))
            return;
        component.Add(item);
        foreach (var i in item.ConnectedItems)
        {
             DFS(i, component);
        }
        foreach (var i in L)
        {
            if (i.ConnectedItems.Contains(item))
                DFS(i);
        }
    }
