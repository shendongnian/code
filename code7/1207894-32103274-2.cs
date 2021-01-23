    private ConcurrentDictionary<string, SemaphoreSlim> fileLocks = new ConcurrentDictionary<string, SemaphoreSlim>();
    
    public async Task WriteToCardAsync(string strFileName, IEnumerable<string> listLinesToWrite)
    {
       var semaphoreSlim = fileLocks.GetOrAdd(strFileName, new SemaphoreSlim(1, 1));
       await semaphoreSlim.WaitAsync();
       try
       {
           IStorageItem item = await folder.GetItemAsync(strFileName);
          StorageFile file = (StorageFile)item;
            await Windows.Storage.FileIO.WriteLinesAsync(file, listLinesToWrite);
       }
       finally
       {
           semaphoreSlim.Release();
       }
    }
