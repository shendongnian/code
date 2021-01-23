    IEnumerable<ItemType> items = new[]
    {
        new ItemType() { ID = "A4", ParentID = "A5"},
        new ItemType() { ID = "A5", ParentID = "A2"},
        new ItemType() { ID = "A1", ParentID = "A2"},
        new ItemType() { ID = "A3", ParentID = "A2"},
        new ItemType() { ID = "A2", ParentID = null },
    
    };
    
    var childrenLookup = items.ToLookup(i => i.ParentID);
    
    Func<ItemType, IEnumerable<ItemType>> preOrderTraverse = null;
    preOrderTraverse = new Func<ItemType, IEnumerable<ItemType>>(item =>
    {
        var curNode = Enumerable.Repeat(item, 1);
        var childNodes = childrenLookup[item.ID]
            .OrderBy(i => i.ID)                 // Sort siblings by ID
            .SelectMany(preOrderTraverse);
    
        return Enumerable.Union(curNode, childNodes);
    });
    
    var preOrderTraversal = childrenLookup[null].SelectMany(preOrderTraverse);
    
    foreach(var item in preOrderTraversal)
        Console.WriteLine($"{item.ID}, {item.ParentID}");
