    static void Main(string[] args)
    {
        Random rnd = new Random(12839);
        int[] list = new int[10000];
        for (int i = 0; i < 5000; ++i)
        {
            list[i] = rnd.Next();
        }
        Stopwatch sw = Stopwatch.StartNew();
        for (int i = 0; i < 10000; ++i)
        {
            for (int j = 0; j < 5000; ++j)
            {
                list[j + 5000] = rnd.Next();
            }
            Array.Sort(list, (a, b) => b - a);
        }
        Console.WriteLine(sw.ElapsedMilliseconds);
        Console.ReadLine();
    }
