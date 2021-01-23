    private void ComboBox_LostFocus(object sender, EventArgs e)
    {
        if(((ComboBox)sender).SelectedIndex == -1)
        {
            //Text entered by user is not a part your ItemsSource's Item
            SaveButton.IsEnabled = false; 
        }
        else
        {
            //Text entered by user is a part your ItemsSource's Item
            SaveButton.IsEnabled = true;
        }
    }
