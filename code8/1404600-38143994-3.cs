    using (var client = new MyWebClient(MyCertificate))
    {
        // optional login/password if website require both. If not, don't set the credentials
        client.Credentials = new System.Net.NetworkCredential(MyLogin, MyPassword);
        client.DownloadFile(MyUrl, MyFile);
    }
