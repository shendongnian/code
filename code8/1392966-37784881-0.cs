    private void phoneComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (phoneComboBox.SelectedIndex != -1)
        {
            nameTextBox.Text = cName[phoneComboBox.SelectedIndex]; 
        }
        else
        {
            nameTextBox.Text = string.Empty;
        }
    }
