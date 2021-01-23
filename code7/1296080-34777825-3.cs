    void Main()
    {
        var test = new SByte[20000, 25000];
        var length = test.GetLength(1);
        var height = test.GetLength(0);
        var lineBuffer = new byte[length];
        var random = new Random();
        //Populate with random data
        for (int h = 0; h < height; h++) 
        {
            random.NextBytes(lineBuffer);
            for (int l = 0; l < length; l++)
            {
                unchecked //Let's use first bit as a sign bit for SByte
                {
                    test[h,l] = (SByte)lineBuffer[l];
                }
            }
        }
        var sw = Stopwatch.StartNew();
        ArraySerializer.SaveToDisk(@"c:\users\ed\desktop\test.bin", test);
        Console.WriteLine(sw.Elapsed);
        sw.Restart();
        var test2 = ArraySerializer.ReadFromDisk(@"c:\users\ed\desktop\test.bin");
        Console.WriteLine(sw.Elapsed);
        Console.WriteLine(test.GetLength(0) == test2.GetLength(0));
        Console.WriteLine(test.GetLength(1) == test2.GetLength(1));
        Console.WriteLine(Enumerable.Cast<SByte>(test).SequenceEqual(Enumerable.Cast<SByte>(test2))); //Dirty hack to compare contents... takes a very long time
    }
