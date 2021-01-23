    static void Main(string[] args)
    {
        var items = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        var rotatedItems = Rotate(items, 4);
        // rotated is now {5, 6, 7, 8, 9, 1, 2, 3, 4}            
        Console.WriteLine(string.Join(", ", rotatedItems));
        Console.Read();
    }
    public static IEnumerable<int> Rotate(IEnumerable<int> items, int places)
    {
        return items.Skip(places).Concat(items.Take(places));
    }
