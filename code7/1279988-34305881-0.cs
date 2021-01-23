    static void Main(string[] args)
    {
        const int COUNT = 66478557;
        const int UNIQUE_COUNT = 59018056;
        // create a bunch of 8-byte arrays:
        var arrays = new List<byte[]>(COUNT);
        for (long i = 0; i < COUNT; ++i)
            arrays.Add(BitConverter.GetBytes(i % UNIQUE_COUNT));
        // the HashSet we'll be abusing (i'll plug in a better comparer later):
        var hs = new HashSet<byte[]>(EqualityComparer<byte[]>.Default);
        //var hs = new HashSet<byte[]>(new ByteArrayComparer());
        var sw = Stopwatch.StartNew();
        for (int i = 0; i < COUNT; ++i)
            hs.Add(arrays[i]);
        sw.Stop();
        Console.WriteLine("New HashSet: " + sw.Elapsed.TotalMilliseconds);
        // clear the collection (doesn't reset capacity):
        hs.Clear();
        // Do the adds again, now that the HashSet has suitable capacity:
        sw.Restart();
        for (int i = 0; i < COUNT; ++i)
            hs.Add(arrays[i]);
        sw.Stop();
        Console.WriteLine("Warmed HashSet: " + sw.Elapsed.TotalMilliseconds);
    }
