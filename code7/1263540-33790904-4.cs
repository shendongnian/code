    private void ComboBox_Selected(object sender, RoutedEventArgs e)
    {
        var item = Combo.SelectedItem as ComboBoxItem;
        if (item != null)
        {
            RedGrid.Visibility = System.Windows.Visibility.Visible;
        }
    }
