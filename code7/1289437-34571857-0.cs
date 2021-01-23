    private bool PingWebSite(string url)
    {
        try
        {
            WebRequest.Create(url).GetResponse();
            return true;
        }
        catch
        {
            return false;
        }
    }
