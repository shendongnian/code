        void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            foreach (var removedItem in e.RemovedItems.Cast<Item>())
            {
                removedItem.IsSelected = false;
            }
            foreach (var addedItem in e.AddedItems.Cast<Item>())
            {
                addedItem.IsSelected = true;
            }
            Title = ((ViewModel) DataContext).Items.Count(item => item.IsSelected).ToString();
        }
