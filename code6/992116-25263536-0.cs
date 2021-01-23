    private async void MainPageLoaded(object sender, RoutedEventArgs e)
    {
        SystemTray.ProgressIndicator = new ProgressIndicator();
        SystemTray.ProgressIndicator.IsIndeterminate = true;
        SystemTray.ProgressIndicator.Text = "Loading...";
        ShowHideProgressIndicator(true);
        try
        {
            var json = await SyncDbIfNeedAsync();
        }
        catch (Exception e)
        {
            MessageBox.Show("Unexpected error");
        }
        ShowHideProgressIndicator(false);
    }
    private void ShowHideProgressIndicator(Boolean isVisible)
    {
        SystemTray.ProgressIndicator.IsVisible = isVisible;
        SystemTray.ProgressIndicator.IsIndeterminate = isVisible;
        Debug.WriteLine("ShowHide: " + isVisible);
    }
    private async Task<string> SyncDbIfNeedAsync()
    {
        if (!MySettings.IsCategorySynced())
        {
            HttpClient httpClient = new HttpClient();
            return await httpClient.GetStringAsync(MyConstants.UrlGetAllCategory);
            MessageBox.Show(json);
        }
    }
