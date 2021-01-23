    private void AddToTreeView()
    {
        TreeViewItem root = new TreeViewItem();
        foreach (string line in ReadLines())
        {
            var parts = line.Split(new char[] { '.' },StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length == 1)
            {
                root.Header = parts[0].Split(':')[0];
                root.Tag = line;
            }
            else
            {
                TreeViewItem node = root;
                foreach (var part in parts)
                {
                    var header = part.Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries)[0];
    
                    if(!IfExists(node, header, ref node))
                    {
                        node.Items.Add(new TreeViewItem()
                        {
                            Header = header,
                            Tag = line
                        });
                        node = root;
                    }
                }
            }
        }
        treeView.Items.Add(root);
    }
    
    private bool IfExists(TreeViewItem itm, string header, ref TreeViewItem which)
    {
                
        if (itm.Header as string == header)
        {
            which = itm;
            return true;
        }
        foreach (TreeViewItem i in itm.Items)
        {
            if (i.Header as string == header)
            {
                which = i;
                return true;
            }
            else if (i.HasItems)
            {
                if (IfExists(i, header, ref which))
                    return true;
            }
        }
        return false;
    }
