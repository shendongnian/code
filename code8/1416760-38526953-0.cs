    private bool _confirmed;
    private void CheckBox_PreviewMouseDown(object sender, 
        System.Windows.Input.MouseButtonEventArgs e)
    {
        if(!_confirmed)
        if (MessageBox.Show("Are you sure?", "Confirm", MessageBoxButton.YesNo) 
            == MessageBoxResult.Yes)
        {
            _confirmed = true;
            Checked = true;
        }
    }
