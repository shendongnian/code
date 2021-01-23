    public virtual Task Save(String path)
    {
        if (NewWords.Any())
        {
            return FileManager.WriteDictionary(path, NewWords, true);
        }
        return Task.CompletedTask;
    }
