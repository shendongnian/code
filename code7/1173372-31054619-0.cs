    public IEnumerable<string> GetItems()
    {
        Console.WriteLine("yielding a");
        yield return "a";
        Console.WriteLine("yielding b");
        yield return "b";
        Console.WriteLine("yielding c");
        yield return "c";
    }
