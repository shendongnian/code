    class Test
    {
    	public List<int> Ids { get; set; } = new List<int> { 1, 2 };
    }
    var test = new Test { Ids = { 1, 3 } };
    foreach (var n in test)
    {
        Console.WriteLine(n);
    }
