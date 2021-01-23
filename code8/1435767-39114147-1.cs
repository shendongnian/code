    private void removebtn_Click(object sender, RoutedEventArgs e)
    {
        var itemsToRemove = ListBoxPlayList.SelectedItems;
        foreach (var item in itemsToRemove)
        {
            fileDictionary.Remove(item.ToString());
            ListBoxPlayList.Remove(item);
        }
    }
