    var port = 22;
    string host = "localhost";
    string username = "user";
    string password = "password";
    string localPath = @"C:\temp";
    using (var client = new SftpClient(host, port, username, password))
    {
        client.Connect();
        var files = client.ListDirectory("");
        var tasks = new List<Task>();
        foreach (var file in files)
        {                        
            tasks.Add(DownloadFileAsync(file.FullName, localPath + "\\" + file.Name));
        }
        await Task.WhenAll(tasks);
        client.Disconnect();
    }
    ...
    async Task DownloadFileAsync(string source, string destination)
    {
        using (var saveFile = File.OpenWrite(destination))
        {
            var task = Task.Factory.FromAsync(client.BeginDownloadFile(source, saveFile), client.EndDownloadFile);
            await task;
        }
    }
