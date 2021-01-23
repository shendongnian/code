    async Task SendMyKeysAsync()
    {
        do
        {
            SendKeys.Send("whatever");
            await Task.Delay(TimeSpan.FromSeconds(1));
        } while (thePixelIsStillRed);
    }
