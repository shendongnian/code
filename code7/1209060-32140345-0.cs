    public async Task DownloadFile(string url, string fileName)
    {
        using (WebClient client = new WebClient())
        {
            client.DownloadProgressChanged += (o, e) =>
            {
                //Console.WriteLine(e.BytesReceived);
            };
            await client.DownloadFileTaskAsync(url, filename);
        }
    }   
