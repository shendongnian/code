    if (treeView1.SelectedNode != null)
    {
        TreeNode tn =treeView1.SelectedNode.Nodes.Add(hlitem.Key.ToString());
        tn.ImageIndex = yourIndex;
    }
    else 
    {
        TreeNode tn =treeView1.Nodes[0].Nodes.Add(hlitem.Key.ToString());
        tn.ImageIndex = yourIndex;
    }
