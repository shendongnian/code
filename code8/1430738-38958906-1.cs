    static void Main(string[] args)
    {
        var doubles = args.Select(a => Convert(a)).ToArray();
        var valid = doubles.All(a => !double.IsNaN(a));
    }
