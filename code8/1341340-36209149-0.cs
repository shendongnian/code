    var names = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
    {
        { "Alice", "Alice" },
        { "Bob", "Bob" },
        { "Charles", "Charles" }
    };
    
    Console.WriteLine(names["alice"]); // Alice
    Console.WriteLine(names["aLICe"]); // Alice
