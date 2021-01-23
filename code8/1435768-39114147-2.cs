    private void removebtn_Click(object sender, RoutedEventArgs e)
    {
    	object[] itemsToRemove = new object[ListBoxPlayList.SelectedItems.Count];
    	ListBoxPlayList.SelectedItems.CopyTo(itemsToRemove, 0);
    	foreach (var item in itemsToRemove)
    	{
    		fileDictionary.Remove(item.ToString());
    		ListBoxPlayList.Items.Remove(item);
    	}
    }
