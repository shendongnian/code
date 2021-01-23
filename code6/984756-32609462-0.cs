    var treeViewItem = sender as TreeViewItem;
    if (treeViewItem.Items.OfType<TreeViewItem>().All(item => !item.IsMouseOver))
    {
        //do my stuff
    }
