    private static void Main(string[] args)
    {
        var raw = new double[,,]
        {
            {
                {1, 2},
                {3, 4}
            },
            {
                {5, 6},
                {7, 8}
            }
        };
        Console.WriteLine(raw[0, 0, 0]); //1
        Console.WriteLine(raw[1, 1, 0]); //7
        Console.ReadKey();
    }
