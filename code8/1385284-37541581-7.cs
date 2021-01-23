    private void PopulateBranchesIntoUi()
    {
        var firstNode = parser.Nodes.First();
        var rootNode = new TreeViewItem { Header = firstNode.Key };
        BuildTreeViewItems(rootNode, firstNode.Nodes);
        projectHeirarchyTreeview.Items.Add(rootNode);
    }
