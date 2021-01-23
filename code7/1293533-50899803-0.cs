    Item prevSelection = null;
        private void _listView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Item selected = null;
            foreach (var item in e.AddedItems)
            {
                selected = item as Item;
            }
            if (selected != null && selected != prevSelection)
            {
                prevSelection = selected;
                _listView.DeselectRange(new ItemIndexRange(0, (uint)_collection.Count));
                _listView.SelectedItem = selected; //will rise event again
                selected = prevSelection = null;
            }
        }
