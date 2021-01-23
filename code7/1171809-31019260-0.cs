    public async Task SaveToFileAsync(string fullPath, line)
    {
        using (var sw = File.CreateText(fullPath))
        {
            await sw.WriteLineAsync(str);
        }
        Log("Saved in thread: {0} to {1}", 
           Environment.CurrentManagedThreadId,
           fullPath);
    }
    
    public async Task SaveToFilesAsync(string path, List<string> list)
    {
        await Task.WhenAll(
            list
                .Select((line, i) =>
                    SaveToFileAsync(
                        string.Format(
                            @"{0}\{1}_element.txt",
                            path,
                            i),
                        line));
    }
