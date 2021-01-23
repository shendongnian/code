    public async Task DoWorkAsync(string data, string file)
    {
        ...
        await sourceStream.WriteAsync(...);
        ...
    }
    IEnumerable<string> fileNames = new string[] { "file1.txt", "file2.txt" };
    Task[] writingTasks = fileNames
                              .Select(fileName => DoWorkAsync("some text", fileName))
                              .ToArray();
    await Task.WhenAll(writingTasks);
