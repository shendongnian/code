    public void DownloadFile()
    {
        using(var client = new WebClient())
        {
            client.DownloadFile(new Uri("http://www.acromix.net16.net/download/test.exe"), "test.exe");
        }
    }
