    ItemCollection ic = treeView.Items;
    string yourNode = "Sequences";
    foreach (TreeViewItem tvi in ic)
    {
        if (yourNode.StartsWith(tvi.Tag.ToString()))
        {
           tvi.IsExpanded = true;
           break;
        }
    }
