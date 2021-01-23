    private void AddNode(
        List<Data> data, string parentKey, Node parent)
    {
        var parentLevel = parent.Tag;
        var counter = 1;
        foreach(var item in 
            data.Where(x => x.ParentKey == parentKey))
        {
            var node = new TreeNode() 
                { Tag = $"{parentLevel}.{counter++}" };
            
            node.Text = $"{node.Tag} {item.Text}";
            
            parentNode.Nodes.Add(node);
            AddNode(data, item.Key, node);
        }
    }
    
