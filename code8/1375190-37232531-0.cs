    private static void Main()
    {
        int number = 450;
        var query = Enumerable.Repeat("*", number / 100);
        Console.WriteLine(string.Join(null, query));
        Console.ReadKey();
    }
