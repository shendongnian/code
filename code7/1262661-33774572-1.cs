    private void DataGrid_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var SelectedItemsCasted = SelectedItems as IList<object>;
            if (SelectedItemsCasted == null)
                return;
    
            foreach (object addedItem in e.AddedItems)
            {
                SelectedItemsCasted.Add(addedItem);
            }
    
            foreach (object removedItem in e.RemovedItems)
            {
                SelectedItemsCasted.Remove(removedItem);
            }
        }
