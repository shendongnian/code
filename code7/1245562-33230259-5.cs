    protected override async void OnNavigatedTo(NavigationEventArgs e)
    {
        await Task.Delay(1);
        var result = await ShowPopup();
    }
    private Task<ContentDialogResult> ShowPopup()
    {
        return loginDialog.ShowAsync().AsTask();
    }
