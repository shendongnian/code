    treePanel.Controls.Clear();
    TreeView[] treeList = new TreeView[codebaseCount]; //But I recommend you use List<TreeView> instead of TreeView[];
    for (int i = 0; i < codebaseCount; i++)
    {
        var tree = new TreeView();
        tree.ID = "treelist" + i.ToString();
        tree.TreeNodePopulate += TreeBranch_SelectedNodePopulate;
        tree.SelectedNodeChanged += TreeBranch_SelectedNodeChanged;
        TreeNode newNode = new TreeNode(newName,newName);
        newNode.SelectAction = TreeNodeSelectAction.None;
        newNode.Expand();
        tree.Nodes.Add(newNode);
        tree.ExpandDepth = 2;
        treePanel.Controls.Add(tree);
        treeList[i] = tree;        
        // more code ...
    }
