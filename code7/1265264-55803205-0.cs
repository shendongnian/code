    private static unsafe void WriteMemoryMappedFileWithViewStream(long fileSize, byte[] bufferToWrite)
    {
        Console.WriteLine(" ==> Memory mapped file with view stream");
        string fileName = Path.Combine(Path.GetTempPath(), "MemoryMappedFileWriteTest-MmfViewStream.bin");
        if (File.Exists(fileName))
        {
            File.Delete(fileName);
        }
        string mapName = Guid.NewGuid().ToString();
        var stopWatch = Stopwatch.StartNew();
        using (var memoryMappedFile = MemoryMappedFile.CreateFromFile(fileName, FileMode.Create, mapName, fileSize, MemoryMappedFileAccess.ReadWrite))
        {
            var viewStream = memoryMappedFile.CreateViewStream(0, fileSize, MemoryMappedFileAccess.Write);
            GC.SuppressFinalize(viewStream);
            using (viewStream.SafeMemoryMappedViewHandle)
            {
                var numberOfPages = fileSize / bufferToWrite.Length;
                for (int page = 0; page < numberOfPages; page++)
                {
                    viewStream.Write(bufferToWrite, 0, bufferToWrite.Length);
                }                
                Console.WriteLine("All bytes written in MMF after {0} seconds ({1} MB/s). Will now close MMF. This may be long since some content may not have been flushed to disk yet.", stopWatch.Elapsed.TotalSeconds, GetSpeed(fileSize, stopWatch));
            }
        }
        Console.WriteLine("File is now closed after {0} seconds ({1} MB/s)", stopWatch.Elapsed.TotalSeconds, GetSpeed(fileSize, stopWatch));
    }
