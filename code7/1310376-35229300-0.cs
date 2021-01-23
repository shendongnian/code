    if (treeView1.Nodes.Count == 0)
    {
        TreeNode newGuy = new TreeNode("New_SubItem");
        treeView1.Nodes.Add(newGuy);
        treeView1.SelectedNode = newGuy;
        newGuy.BeginEdit();
    }
    if (treeView1.Nodes[0].Nodes.Count == 0)
    {
        TreeNode n = treeView1.SelectedNode;
        TreeNode n3 = new TreeNode("New_SubItem");
        n.Nodes.Add(n3);
        n3.BeginEdit();
        treeView1.ExpandAll();
        return;
    }
