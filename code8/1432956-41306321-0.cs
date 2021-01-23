    List<TreeViewItem> expandedTVI = new List<TreeViewItem>();
    foreach (TreeViewItem item in treeView1.Items)
    {
        if (item.HasItems && item.IsExpanded) //if it has children, and the parent is expanded
        {
            foreach (TreeViewItem child in item.Items)
                expandedTVI.Add(child); //add the child to the list
        }
        expandedTVI.Add(item); //always add the parent to the list
    }
