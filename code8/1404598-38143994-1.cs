    using (var client = new System.Net.WebClient(MyCertificate))
    {
        client.Credentials = new System.Net.NetworkCredential(MyLogin, MyPassword);
        client.DownloadFile(MyUrl, MyFile);
    }
