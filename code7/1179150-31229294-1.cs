    public static void Main(string[] args)
    {
        var list = new List<List<int>>() { new List<int> { 1, 1, 2 }, new List<int> { 1, 2, 3 }, new List<int> { 1, 1, 2 } };
        var res = list.Distinct(new CustomEqualityComparer());
        Console.WriteLine("Press any key to continue.");
        Console.ReadLine();
    }
