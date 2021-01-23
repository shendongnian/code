    public async Task DownloadFileAsync()
    {
        using(var client = new WebClient())
        {
             await client.DownloadFileTaskAsync(
                new Uri("http://www.acromix.net16.net/download/test.exe"),
                "test.exe");
        }
    }
