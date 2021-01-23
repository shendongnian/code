    if (treeView1.Nodes.Count == 0)
        {
            TreeNode newGuy = new TreeNode("New_SubItem");
            treeView1.Nodes[0].Nodes.Add(newGuy);
            newGuy.BeginEdit();
            return;
        }
