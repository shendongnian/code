    private TreeViewItem BuildTreeViewItems(Dictionary<string, DictionaryParserTreeview> nodes)
    {
        var item = new TreeViewItem();
        foreach (var node in nodes)
        {
            Debug.WriteLine(node.Key);
            
            item.Header = node.Key;
            if (node.Value.Nodes.Count > 0)
                item.Items.Add(BuildTreeViewItems(node.Value.Nodes));
            
        }
        return item;
    }
