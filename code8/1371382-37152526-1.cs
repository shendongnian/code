    public async Task<bool> IsFilePresent(string fileName)
    {
        var item = await ApplicationData.Current.LocalFolder.TryGetItemAsync(fileName);
        return item != null;
    }
