    int[] lengths = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32, 64, 128, 256, 512, 1024, 2048, 4096 };
    string[] strs = new string[lengths.Length];
    long[] deltaMemory = new long[lengths.Length];
    // We preload the functions we will use
    var str0 = new string('A', 1);
    var length0 = str0.Length;
    long totalMemory0 = GC.GetTotalMemory(true);
    long lastTotalMemory = totalMemory0;
    for (int i = 0; i < lengths.Length; i++)
    {
        strs[i] = new string((char)('A' + i), lengths[i]);
        long totalMemory = GC.GetTotalMemory(true);
        deltaMemory[i] = totalMemory - lastTotalMemory - lengths[i] * 2;
        lastTotalMemory = totalMemory;
    }
    Console.WriteLine("IntPtr.Size: {0}", IntPtr.Size);
    for (int i = 0; i < lengths.Length; i++)
    {
        Console.WriteLine("For size: {0}, extra memory: {1}", strs[i].Length, deltaMemory[i]);
    }
