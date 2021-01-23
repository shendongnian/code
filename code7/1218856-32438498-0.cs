    private void Border_LostFocus(object sender, RoutedEventArgs e)
    {
      ((Border)sender).BorderBrush = new SolidColorBrush(Colors.DarkGray);
    }
    private void Border_GotFocus(object sender, RoutedEventArgs e)
    {
      ((Border)sender).BorderBrush = new SolidColorBrush(Colors.LightBlue);
    }
