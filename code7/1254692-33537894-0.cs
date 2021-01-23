    private static void Main(string[] args)
    {
        Random random = new Random();
        int[] positive = Enumerable.Range(0, 1000000).Select(n => random.Next(1, 1000000)).ToArray();
        int[] negative = Enumerable.Range(0, 1000000).Select(n => random.Next(-1000000, -1)).ToArray();
        var zeroSum = positive.Intersect(negative, new AbsoluteEqual());
        foreach (var i in zeroSum)
        {
            Console.WriteLine("{0} - {1} = 0", i, i);
        }
    }
