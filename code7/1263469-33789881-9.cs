    static void Main(string[] args)
    {
        var elements = Enumerable.Range(0, 1000000).Select(i => i.ToString()).ToList();
        //Initialize collection here
        //...
        var sw = new Stopwatch();
        sw.Start();
        foreach (var element in elements)
        {
            //Add element to collection here
            //...
        }
        sw.Stop();
        Console.WriteLine("Elapsed time: {0}", sw.Elapsed);
    }
