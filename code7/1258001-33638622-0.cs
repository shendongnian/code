    private void AdvancedToggleButton_Click(object sender, RoutedEventArgs e)
    {
        var newVisibility = (bool)(sender as ToggleButton).IsChecked ? Visibility.Visible : Visibility.Collapsed;
        this.theDataGrid.Columns[0].Visibility = newVisibility;
    }
