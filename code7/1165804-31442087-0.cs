    private bool busy;
    private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
      if (!this.busy)
      {
        this.busy = true;
        /*
         * If items were added to the end of the list,
         * reverse the list appropriately.
         * Removed items are self-handling.
         */
        if (e.AddedItems.Count > 0)
        {
          List<CheckedListItem<Customer>>  reversed = new List<CheckedListItem<Customer>>();
          // Reverse newly added items.
          foreach (var item in e.AddedItems)
          {
            listbox1.SelectedItems.Remove(item);
            reversed.Insert(0, (CheckedListItem<Customer>)item);
          }
          // Maintain previously reversed items' orders.
          foreach (var item in listbox1.SelectedItems)
          {
            reversed.Add((CheckedListItem<Customer>)item);
          }
          // Clear and reset selections to trigger SelectedIndex change.
          listbox1.UnselectAll();
          foreach (var item in reversed)
          {
            listbox1.SelectedItems.Add(item);
          }
        }
        int index = listbox1.SelectedIndex;
        string testName = listbox1.SelectedValue == null ? string.Empty : ((CheckedListItem<Customer>)listbox1.SelectedValue).Item.Name;
        System.Console.WriteLine("{0} {1}", index, testName);
        this.busy = false;
      }
    }
