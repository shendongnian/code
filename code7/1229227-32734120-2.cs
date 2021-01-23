    var dict = new Dictionary<int, TreeNode>();
    var orphans = new Queue<Hierarchymain>();
    foreach (Hierarchymain item in hierarchy)
    {
        TreeNode newNode = new TreeNode(item.Label);
        TreeNode parent;
        if (dict.TryGetValue(item.ParentID, out parent))
            parent.Nodes.Add(newNode);
        else if (item.ParentID == 0)
            treeView1.Nodes.Add(newNode);
        else
            orphans.Enqueue(item);
        dict.Add(item.ID, newNode);
    }
    // processing nodes, whose parents were created later
    foreach (Hierarchymain item in orphans)
    {
        TreeNode orphan = dict[item.ID];
        TreeNode parent;
        if (dict.TryGetValue(item.ParentID, out parent))
            parent.Nodes.Add(orphan); // parent found
        else
            treeView1.Nodes.Add(orphan); // the node is a real orphan, adding to the root
    }
