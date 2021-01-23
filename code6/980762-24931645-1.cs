    private void ComboBox_LostFocus(object sender, ........ e)
    {
        if(((ComboBox)sender).SelectedIndex == -1)
        {
            //Text entered by user is not a part your ItemsSource's Item
            SaveButton.IsEndabled = false; 
        }
        else
        {
            //Text entered by user is a part your ItemsSource's Item
            SaveButton.IsEndabled = true;
        }
    }
