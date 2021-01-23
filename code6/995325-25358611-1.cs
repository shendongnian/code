    private void SetButtonColor(Button toDefaultColor, Button toGreenColor)
    {
        toGreenColor.Background = new SolidColorBrush(Colors.Green);
        toDefaultColor.Background = new SolidColorBrush(Colors.LightGray);
    }
    private void secondButton_Click(object sender, RoutedEventArgs e)
    {
        SetButtonColor(firstButton, (sender as Button));
    }
