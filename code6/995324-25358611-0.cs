    private void firstButton_Click(object sender, RoutedEventArgs e)
    {
        (sender as Button).Background = new SolidColorBrush(Colors.Green); 
        secondButton.Background = new SolidColorBrush(Colors.LightGray);
    }
    private void secondButton_Click(object sender, RoutedEventArgs e)
    {
        (sender as Button).Background = new SolidColorBrush(Colors.Green);
        firstButton.Background = new SolidColorBrush(Colors.LightGray);
    }
