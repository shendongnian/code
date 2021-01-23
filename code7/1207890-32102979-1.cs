    private readonly locks = new Dictionary<string, AsyncLock>();
    
    public async void WriteToCard(string strFileName, IEnumerable<string> listLinesToWrite)
    {
        var lock = locks.GetOrAdd(strFileName, () => new AsyncLock());
    
        using (await lock.LockAsync())
        {
            IStorageItem item = await folder.GetItemAsync(strFileName);
            StorageFile file = (StorageFile)item;
    
            await Windows.Storage.FileIO.WriteLinesAsync(file, listLinesToWrite);
        }
    }
