    try
    {
        var client = new WebClient();
        client.DownloadString("...");
    }
    catch (WebException ex)
    {
        var statusCode = ((HttpWebResponse)ex.Response).StatusCode;
        ...
    }
