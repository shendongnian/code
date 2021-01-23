    //create a new tree..
    var tree = new Tree<string>("root-item");
    
    //populate the tree with 10 items with 10 sub items
    for (int i = 0; i < 10; i++)
    {
        var node = tree.Root.AddChild($"item-{i}");
        for (int w = 0; w < 10; w++)
        {
            node.AddChild($"sub-item-{i}-{w}");
        }
    }
    
    //find the root node
    var findNode = tree.Root.FindByValue("root-item");
    
    //find a sub node item
    findNode = tree.FindByValue("sub-item-1-1");
