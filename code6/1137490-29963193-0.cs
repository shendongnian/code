    private IList<ImageListViewItem> GetItems(int flag)
    {
        IList<ImageListViewItem> items;
        if (flag == 1)
        {
            items = imageListView1.Items
        }
        else
        {
            items = imageListView1.SelectedItems.Take(1).ToList();
        }
        return items;
    }
