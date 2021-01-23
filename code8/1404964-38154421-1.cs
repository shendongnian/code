    private void Window_ContentRendered(object sender, EventArgs e)
    {
        SolidColorBrush YourBrush = Brushes.Green;
        // Set the value
        Application.Current.Resources["DynamicColor"] = YourBrush;         
    }
    private void Button_Click(object sender, RoutedEventArgs e)
    {
        SolidColorBrush YourBrush = Brushes.Orange;
        // Set the value
        Application.Current.Resources["DynamicColor"] = YourBrush;
    }
