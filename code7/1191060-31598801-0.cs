    if (selectedItemsListBox.SelectedItems.Count > 0)
    {
        List<object> itemsToMove = (from object item in selectedItemsListBox.SelectedItems select item).ToList();
        int numItems = selectedItemsListBox.Items.Count;
        // If up arrow was clicked
        if (sender.ToString().Contains("▲"))
        {
            for (int i = 0; i < itemsToMove.Count; i++)
            {
                var selectedItem = itemsToMove[i];
                int oldIndex = selectedItemsListBox.Items.IndexOf(selectedItem);
                int newIndex = oldIndex == 0 ? numItems - 1 : oldIndex - 1;
                selectedItemsListBox.Items.Remove(selectedItem);
                selectedItemsListBox.Items.Insert(newIndex, selectedItem);
                selectedItemsListBox.SetSelected(newIndex, true);
            }
        }
        // If down arrow was clicked
        else if (sender.ToString().Contains("▼"))
        {
            for (int i = itemsToMove.Count - 1; i >= 0; i--)
            {
                var selectedItem = itemsToMove[i];
                int oldIndex = selectedItemsListBox.Items.IndexOf(selectedItem);
                int newIndex = oldIndex == numItems - 1 ? 0 : oldIndex + 1;
                selectedItemsListBox.Items.Remove(selectedItem);
                selectedItemsListBox.Items.Insert(newIndex, selectedItem);
                selectedItemsListBox.SetSelected(newIndex, true);
            }
        }
    }
