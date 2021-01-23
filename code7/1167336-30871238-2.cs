    using (var client = new HeadOnlyClient())
    {
        try
        {
            client.DownloadString("http://google.com");
        }
        catch (Exception ex)
        {
            // URL is not accessible.
        }
    }
