    using System.Threading.Tasks;
    public async Task WriteToFile(string text)
    {
        StorageFile file = await folder.GetFileAsync(logFileName);
        
        lock (fileLockObject)
        {
            Task<Stream> streamTask = file.OpenStreamForWriteAsync();
            
            try
            {
                streamTask.Wait();
            }
            catch (AggregateException ex)
            {
                 // You may want to handle errors here
            }
    
            if (!streamTask.IsFaulted)
            {
                using (StreamWriter writer = new StreamWriter(streamTask.Result))
                {
                    writer.Write(text);
                }
            }
        }
    }
