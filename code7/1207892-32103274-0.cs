    private ConcurrentDictionary<string, Lazy<SemaphoreSlim>> fileLocks = new ConcurrentDictionary<string, Lazy<SemaphoreSlim>>();
    
    public async Task WriteToCardAsync(string strFileName, IEnumerable<string> listLinesToWrite)
    {
       var semaphoreSlim = fileLocks.GetOrAdd(strFileName, new Lazy(() => new SemaphoreSlim(1, 1), true));
       await semaphoreSlim.Value.WaitAsync();
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
