    public async Task BackupFile()
    { 
      await Task.Run(() =>
      {
        var uploadTasks = new List<Task>();
        for (var i = 0; i < partCount; i++)
        {
            var uploadTask = Task.Run(() => upload(FilePart));
        }
        Task.WhenAll(uploadTasks).Wait();
        Console.WriteLine("Upload Successful");
      });
    }
