    WebClient req = new WebClient();
    string url = "ftp://myftp/myftpfolder" +"yourfilename";
    req.Credentials = new NetworkCredential("  ", " ");
    try
    {
     byte[] FData = req.DownloadData(url);
     string fString = System.Text.Encoding.UTF8.GetString(FData);
     Console.WriteLine(fString);
    }
    catch (WebException e)
    {}
