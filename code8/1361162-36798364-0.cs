    SemaphoreSlim semaphore = new SemaphoreSlim(1);
    
    public static async Task<Stream> CreateAsync(string path)
            {
    StorageFile file ;
    try
                {
                    await semaphore.WaitAsync();
                StorageFolder folder = await Directory.GetFolderAsync(Path.GetDirectoryName(path));
                file= await folder.CreateFileAsync(Path.GetFileName(path), CreationCollisionOption.ReplaceExisting);
    }
    catch (Exception ex)
                {
                   
                }
                finally
                {
                    semaphore.Release();
                return await.          file.OpenStreamForWriteAsync();
    }
            }
