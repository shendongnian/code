    public async Task BackupFileAsync()
    {
        var uploadTasks = new List<Task>();
        for (var i = 0; i < partCount; i++)
        {
            var uploadTask = Task.Run(() => upload(FilePart));
            uploadTasks.Add(uploadTask)
        }
        await Task.WhenAll(uploadTasks);
        Console.WriteLine("Upload Successful");
    }
