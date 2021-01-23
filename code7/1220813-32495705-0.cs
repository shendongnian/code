    private void OnTreeViewAfterCheck(object sender, TreeViewEventArgs e)
    {
        var treeView = (TreeView)sender;
        treeView.AfterCheck -= OnTreeViewAfterCheck;
        SetChildCheckedState(e.Node);
        treeView.AfterCheck += OnTreeViewAfterCheck;
    }
    private void SetChildCheckedState(TreeNode treeNode)
    {
        foreach (TreeNode childNode in treeNode.Nodes)
        {
            childNode.Checked = treeNode.Checked;
            // Call recursively if you like
            SetChildCheckedState(childNode);
        }
    }
