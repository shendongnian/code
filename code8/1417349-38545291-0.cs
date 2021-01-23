    private async void Button1_Click(object sender, RoutedEventArgs e)
    {
        Button1.Background = Brushes.Red;
        Button1.Content = "Clicked State";
        await Task.Delay(8000);
        Button1.Background = Brushes.Transparent;
        Button1.Content = "Click Me";
    }
