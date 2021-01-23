    using (var client = new WebClient())
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
