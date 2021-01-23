    private void dpkClaim1_SelectionChanged(object sender, RoutedEventArgs e)
    {
         DatePicker datePicker = sender as DatePicker;
        if (cbxNoClaims.SelectedItem.ToString() == "1")
        {
            dpkClaim1.IsEnabled = true;
    
        }
        else dpkClaim1.IsEnabled = false;
    }
