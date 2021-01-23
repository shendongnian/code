    public void Button_Click(object sender, EventArguments arg)
    {
      List<ListViewItem> mySelectedItems = new List<ListViewItem>();
    
      foreach(ListViewItem item in myListView.SelectedItems)
      {
        mySelectedItems.Add(item);
      }
    }
