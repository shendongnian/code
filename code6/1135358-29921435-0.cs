    class FileDownLoader
    {
        public async byte[] DownloadAsync(string url)
        {
            await Task.Delay(2000);
            return new byte[] { 1, 2, 3, 4 };
        }
    }
