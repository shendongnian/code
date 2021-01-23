    public async Task SaveToFilesAsync(string path, List<string> list, CancellationToken ct)
    {
        int count = 0;
        var writeOperations = new List<Task>(list.Count);
        foreach (var str in list)
        { 
            string fullPath = path + @"\" + count.ToString() + "_element.txt";
            writeOperations.add(SaveToFileAsync(fullPath, str, ct));
            count++;
            ct.ThrowIfCancellationRequested();
        }
        await Task.WhenAll(writeOperations);
    }
    private async Task SaveToFileAsync(string path, string line, CancellationToken ct)
    {
        using (var sw = File.CreateText(path))
        {
            await sw.WriteLineAsync(line);
        }
        NLog.Trace("Saved in thread: {0} to {1}", 
            Environment.CurrentManagedThreadId, 
            fullPath);
        ct.ThrowIfCancellationRequested();
    }
