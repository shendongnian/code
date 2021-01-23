    Task DownloadFileAsync(string source, string destination)
    {
        return Task.Run(() =>
        {
            using (var saveFile = File.OpenWrite(destination))
            {
                client.DownloadFile(source, saveFile);
            }
        }
    }
