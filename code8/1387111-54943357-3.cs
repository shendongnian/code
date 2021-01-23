    private Boolean IsValidUri(String uri)
    {
        try
        {
            new Uri(uri);
            return true;
        }
        catch
        {
            return false;
        }
    }
    public ICommand ClickCommand => new Command<string>(async (url) =>
    {
        try
        {
            if (!string.IsNullOrEmpty(url))
            {
                if (!url.Trim().StartsWith("http", StringComparison.OrdinalIgnoreCase))
                {
                    url = "http://" + url;
                }
                if (IsValidUri(url))
                {
                    await Browser.OpenAsync(new Uri(url), BrowserLaunchMode.SystemPreferred);
                }
            }
        }
        catch(Exception ex)
        {
            Debug.WriteLine(ex.Message);
        }
    });
