    private readonly AsyncLock _mutex = new AsyncLock();
    
    public async void WriteToCard(string strFileName, IEnumerable<string> listLinesToWrite)
    {
        using (await _mutex.LockAsync())
        {
            IStorageItem item = await folder.GetItemAsync(strFileName);
            StorageFile file = (StorageFile)item;
    
            await Windows.Storage.FileIO.WriteLinesAsync(file, listLinesToWrite);
        }
    }
