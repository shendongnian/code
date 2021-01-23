    try
    {
        WebClient cHttp = new WebClient();
        string htmlCode = cHttp.DownloadString(path); 
    }
    catch(Exception e)
    {
        Debug.WriteLine(e);
    }
