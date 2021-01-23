    private async void Button_Click(object sender, RoutedEventArgs e)
    {
        var button = (Button)sender;
        button.IsEnabled = false;
        await DoTheBootstrapping();
        button.IsEnabled = true;
    }
