    private void SourceCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           // await LoadData();
        object selectedItem = SourceCombo.SelectedItem;
        DestinationCombo.Items.Clear();
        DestinationCombo.Items.AddRange(cities.ToArray<String>());
        DestinationCombo.Items.Remove(selectedItem);
        }
