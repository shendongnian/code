    public async Task SaveToFilesAsync(
            string path,
            IEnumerable<string> list,
            CancellationToken ct)
    {
        await Task.WhenAll(list.Select((str, count) => WriteToFile(path, str, count));
    }
    
