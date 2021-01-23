    void ProcessFile(string path)
    {
        try
        {
            var fileInfo = new FileInfo(path);
            var fileSizeInMb = (int)(fileInfo.Length >> 20);
            using (new System.Runtime.MemoryFailPoint(fileSizeInMb))
            {
                // Do processing in memory
            }
        }
        catch (InsufficientMemoryException)
        {
            // Do processing on disk
        }
    }
