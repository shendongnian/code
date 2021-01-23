    static void Main()
    {
        List<int> list = new List<int>();
        var results = new[] { 1, 2, 3 };
        results.ToList().ForEach(i => list.Add(i));
        Console.WriteLine(list.Count);
    }
