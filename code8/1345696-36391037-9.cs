    static void Main(string[] args)
    {
        Random rnd = new Random(12839);
        List<int> list = new List<int>();
        for (int i = 0; i < 5000; ++i)
        {
            list.Add(rnd.Next());
        }
        Stopwatch sw = Stopwatch.StartNew();
        for (int i = 0; i < 10000; ++i)
        {
            for (int j = 0; j < 5000; ++j)
            {
                list.Add(rnd.Next());
            }
            list.Sort((a, b) => a.CompareTo(b)); // #1
            list.RemoveRange(0, 5000);
        }
        Console.WriteLine(sw.ElapsedMilliseconds);
        Console.ReadLine();
    }
