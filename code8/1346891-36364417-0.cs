    private void NextButton_Click(object sender, RoutedEventArgs e) 
    {
        if (!CheckBox1.IsChecked && !CheckBox2.IsChecked && !CheckBox3.IsChecked && !CheckBox4.IsChecked)
        {
            // update TextBlock to alert the user 
        }
        else 
        {
            if (CheckBox1.IsChecked) 
            {
                // do something
            }
           // same for other checkboxes
        }
    }
