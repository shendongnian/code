    private static void Main(string[] args)
    {
        var test = new Test();
        var results = new List<int>();
        for (int i = 0; i < 5; i++)
            results.Add(test.GetData(i));
        Task.WaitAll();
        Console.WriteLine(string.Join(",",results));
        Console.ReadLine();
    }
