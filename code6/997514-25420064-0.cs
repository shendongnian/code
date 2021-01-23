    static void Main(string[] args)
    {
        var ab = new MyEquatable("A", "B");
        var target = new MyEquatable("A", "B");
        var array = new[] { ab };
        Console.WriteLine(array.Contains(target)); // False
        
        var list = new List<MyEquatable> { ab };
        Console.WriteLine(list.Contains(target));  // True
        
        var sequence = array.Select(x => x);
        Console.WriteLine(sequence.Contains(target)); // True
    }
