    if (sender is TreeViewItem)
    {
       Item = sender as TreeViewItem;
        //make sure we have a leaf node, if we dont just move on.
        if (Item.ItemsSource == null)
        {
         //do my stuff
        }
    }
