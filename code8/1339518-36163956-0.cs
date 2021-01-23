    private void RadioButton_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
        e.Handled = true;
        var radioButton = sender as RadioButton;
        MessageBoxResult result = MessageBox.Show("Choosing this sample will override any changes you've made. Continue?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);
        if (result == MessageBoxResult.Yes)
        {
            radioButton.IsChecked = true;
        }
    }
