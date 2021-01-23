    private void DisplayProgressIndicator(bool isvisible, string message = "")
    {
        SystemTray.ProgressIndicator.Text = message;
        SystemTray.ProgressIndicator.IsIndeterminate = isvisible;
        SystemTray.ProgressIndicator.IsVisible = isvisible;
    }
