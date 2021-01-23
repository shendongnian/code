    private void RemoveButton_Click(object sender, RoutedEventArgs e)
        {
            foreach (var item in MyListView.SelectedItems.Cast<object>().ToList())
            {
                ItemsCollection.Remove((Item)item);
            }
        }
