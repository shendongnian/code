    protected override async void OnNavigatedTo(NavigationEventArgs e)
    {
        ShowContentDialog("cos");
        await HideContentDialog();
    }
    ContentDialog _contentDialog;
    private void ShowContentDialog(string s)
    {
            _contentDialog = new ContentDialog();
        _contentDialog.Content = s;
        _contentDialog.IsPrimaryButtonEnabled = true;
        _contentDialog.PrimaryButtonText = "OK";
        _contentDialog.Title = "title";
        _contentDialog.ShowAsync();
    }
    private async Task HideContentDialog()
    {
        await Task.Delay(5000);
        _contentDialog.Hide();
    }
