    private async void FooAsync()
    {
        button.IsEnabled = false;
        await Task.Delay(1000).ConfigureAwait(false);
        button.IsEnabled = true;
    }
