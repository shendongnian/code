    public async Task<FileActionStatus> SaveAsync(string path, byte[] data) 
    {
        using (FileStream sourceStream = new FileStream(path,
        FileMode.Append, FileAccess.Write, FileShare.None,
        bufferSize: 4096, useAsync: true))
        {
            await sourceStream.WriteAsync(data, 0, data.Length);
        }
        // return some result.
    }
