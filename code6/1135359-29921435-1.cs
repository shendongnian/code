    public async Task DownloadAndDisplayResultAsync()
    {
        FileDownLoader flDl = new FileDownLoader();
        byte[] result = await flDl.DownloadAsync("test");
        Console.WriteLine("Downloading complete", result[0]);
    }
