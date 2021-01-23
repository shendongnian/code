    private CancellationTokenSource _cts;
    private async void TextChangedHandler(string text)   // async void only for event handlers
    {
        try
        {
            _cts?.Cancel();     // cancel previous search
        }
        catch (ObjectDisposedException)     // in case previous search completed
        {
        }
        using (_cts = new CancellationTokenSource())
        {
            try
            {
                await Task.Delay(TimeSpan.FromSeconds(1), _cts.Token);  // buffer
                var users = await _userService.SearchUsersAsync(text, _cts.Token);
                Console.WriteLine($"Got users with IDs: {string.Join(", ", users)}");
            }
            catch (TaskCanceledException)       // if the operation is cancelled, do nothing
            {
            }
        }
    }
