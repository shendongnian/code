    //Just create an empty file
    FileStream f = File.Create(@"D:\Test.bin");
    f.Close();
    
    long dataLen = 402653184; //3gb represented in 8 byte chunks
    long[] data = new long[dataLen];
    int elementSize = sizeof (long);
    
    Stopwatch sw = Stopwatch.StartNew();
    
    //Open the file, with a default capacity. This allows you to write over the initial capacity of the file
    using (var mmf = MemoryMappedFile.CreateFromFile(@"D:\Test.bin", FileMode.Open, "longarray", data.LongLength * elementSize))
    {
        long offset = 0;
        int chunkLength = 32768; 
    
        while (offset < dataLen)
        {
            using (var accessor = mmf.CreateViewAccessor(offset * elementSize, chunkLength * elementSize))
            {
                for (long i = offset; i != offset + chunkLength; ++i)
                {
                    accessor.Write(i - offset, data[i]);
                }
            }
    
            offset += chunkLength;
        }
    }
    
    Console.WriteLine(sw.Elapsed);
