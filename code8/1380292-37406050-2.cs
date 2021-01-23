    private void ChangeZoom(double change)
    {
        PreviewItem previewItem = _previewItems[_selectedPreview];
        ChromiumWebBrowser browser = new ChromiumWebBrowser();
        foreach (object child in ((Canvas)previewItem.PreviewBorder.Child).Children)
        {
            browser = child as ChromiumWebBrowser;
            if (browser != null)
                break;
        }
        Task<double> task = browser.GetZoomLevelAsync();
        task.ContinueWith(previous =>
        {
            if (previous.IsCompleted)
            {
                double currentLevel = previous.Result;
                browser.SetZoomLevel(currentLevel + change);
            }
            else
            {
                throw new InvalidOperationException("Unexpected failure of calling CEF->GetZoomLevelAsync", previous.Exception);
            }
        }, TaskContinuationOptions.ExecuteSynchronously);
        ZoomLevelTextBox.Text = (Convert.ToDouble(ZoomLevelTextBox.Text) + change).ToString(CultureInfo.CurrentCulture);
    }
