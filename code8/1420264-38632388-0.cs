    try
    {
        using (var client = new WebClient())
        {
            client.DownloadFile(urlToFileOnInternet, pathToFileOnComputer);
        }
    }
    catch (Exception ex)
    {
        Utility.Msg_Error(Master, ex.Message);
    }
