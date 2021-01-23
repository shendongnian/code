    try
    {
        var listB = FooB(count: 0);
        Console.WriteLine(listB.First()); // use the IEnumerable returned
        Console.WriteLine("B did not throw exception!");
    }
    catch (ArgumentException)
    {
        Console.WriteLine("B threw exception!");
    }
