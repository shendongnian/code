    static void Main()
    {
        var ints = DoWork<int[], int>(GetInts, i => i % 2 == 0).Result;
        var longs = DoWork<long[], long>(GetLongs, i => i % 2 == 0).Result;
    }
