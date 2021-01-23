    async void Button_Click(object sender, RoutedEventArgs e)
    {
        await SendMyKeysAsync();
    }
    async Task SendMyKeysAsync()
    {
        SendKeys.Send("whatever");
        await Task.Delay(TimeSpan.FromSeconds(1));
        if (thePixelIsStillRed)
        {
            await SendMyKeysAsync();
        }
    }
