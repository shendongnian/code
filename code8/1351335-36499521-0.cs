    public async virtual Task Save(String path)
    {
        if (NewWords.Any())
        {
            await FileManager.WriteDictionary(path, NewWords, true);
        }
    }
