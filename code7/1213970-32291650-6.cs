    static void DFS(Item item, List<Item> component)
    {
        if (component.Contains(item))
            return;
        component.Add(item);
        item.Visited = true;
        foreach (var i in item.ConnectedItems)
        {
             if (!i.Visited)
                 DFS(i, component);
        }
        foreach (var i in L)
        {
            if (!i.Visited && i.ConnectedItems.Contains(item))
                DFS(i);
        }
    }
