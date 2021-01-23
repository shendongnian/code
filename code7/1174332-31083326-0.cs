    public static void Main(string[] args
    {
        var tests = new []
        {
            new []{0, 1},
            new []{1, 1},
            new []{10, 2},
            new []{100, 3}
        };
        foreach (var p in tests)
            if (dig(p[0]) != p[1]) Console.WriteLine("dig({0}) == {1}", p[0], p[1]);
    }
