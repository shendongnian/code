    async void Button_Click(object sender, RoutedEventArgs e)
    {
        await SendMyKeysAsync();
    }
    async Task SendMyKeysAsync()
    {
        while (thePixelIsStillRed)
        {
            SendKeys.Send("whatever");
            await Task.Delay(TimeSpan.FromSeconds(1));
        }
    }
