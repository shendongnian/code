    IRandomAccessStream stream = await storageFile.OpenAsync(FileAccessMode.ReadWrite, StorageOpenOptions.AllowOnlyReaders);
    stream.Size = 0; // clear the existing content
    using (StreamWriter streamWriter = new StreamWriter(stream.AsStreamForWrite()))
    {                        
        foreach (...)
        {
            await streamWriter.WriteLineAsync(...)
            //await streamWriter.FlushAsync();                            
        }
    }
    await stream.FlushAsync();
    stream.Dispose();
