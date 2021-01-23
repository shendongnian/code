    private TreeViewItem BuildTreeViewItems(Dictionary<string, DictionaryParserTreeview> nodes)
    {
        var item = new TreeViewItem();
        foreach (var node in nodes)
        {
            Debug.WriteLine(node.Key);
            if (node.Value.Nodes.Count == 0)
            {
                // item.Items.Add(node.Key);  <-- don't add a new item.
                item.Header = node.Key;
            }
            else
            {
                item.Header = node.Key;
                item.Items.Add(BuildTreeViewItems(node.Value.Nodes));
            }
        }
        return item;
    }
