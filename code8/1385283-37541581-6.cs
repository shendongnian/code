    private void PopulateBranchesIntoUi()
    {
        var rootNode = new TreeViewItem { Header = "$" };
        BuildTreeViewItems(rootNode, parser.Nodes);
        projectHeirarchyTreeview.Items.Add(rootNode);
    }
    private void BuildTreeViewItems(TreeViewItem parent, Dictionary<string, DictionaryParserTreeview> nodes)
    {
        foreach (var node in nodes)
        {
            Debug.WriteLine(node.Key);
            var item = new TreeViewItem { Header = node.Key };
            BuildTreeViewItems(item, node.Value.Nodes);
            
            parent.Items.Add(item);
        }
    }
