    private void myList_ItemClick(object sender, ItemClickEventArgs e)
    {
        Debug.WriteLine("Clicked item");
        ListView list = sender as ListView;
        ListViewItem listItem = list.ContainerFromItem(e.ClickedItem) as ListViewItem;
    
        if (listItem.IsSelected)
        {
            listItem.IsSelected = false;
            list.SelectionMode = ListViewSelectionMode.None;
        }
        else
        {
            list.SelectionMode = ListViewSelectionMode.Single;
            listItem.IsSelected = true;
        }
    }
