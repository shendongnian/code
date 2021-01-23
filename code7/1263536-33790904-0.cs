    private void ComboBox_Selected(object sender, RoutedEventArgs e)
    {
        var item = Combo.SelectedItem as ComboBoxItem;
        if (item.Content.ToString() == "Visible")
        {
            RedGrid.Visibility = System.Windows.Visibility.Visible;
        }
        else
        
        {
            RedGrid.Visibility = System.Windows.Visibility.Hidden;
        }
    }
