    private void cbxNoClaims_SelectionChanged(object sender, RoutedEventArgs e)
    {
        if (cbxNoClaims.SelectedItem.ToString() == "1")
        {
            dpkClaim1.IsEnabled = true;
        }
        else 
        {
            dpkClaim1.IsEnabled = false;
        }
    }
