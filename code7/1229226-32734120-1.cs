    var dict = new Dictionary<int, TreeNode>();
    foreach (Hierarchymain item in hierarchy)
    {
        TreeNode newNode = new TreeNode(item.Label);
        TreeNode parent;
        if (dict.TryGetValue(item.ParentID, out parent))
            parent.Nodes.Add(newNode);
        else
            treeView1.Nodes.Add(newNode);
        dict.Add(item.ID, newNode);
    }
