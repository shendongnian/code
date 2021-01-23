    List<ListViewDataItem> saveSelectedItems = new List<ListViewDataItem>();
 
    foreach (ListViewDataItem eachItem in sender.SelectedItems)
    {
      saveSelectedItems.Add(eachItem);
    }
 
    foreach (ListViewDataItem item in saveSelectedItems)
    {
      sender.Items.Remove(item);
    }
