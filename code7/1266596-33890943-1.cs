    static void Main(string[] args)
    {
        var data = new List<int> { 7, 10, 0 };
        for (var it = data.GetEnumerator(); it.MoveNext(); )
        {
            Console.WriteLine(it.Current);
        }
    }
