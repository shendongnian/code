    foreach(string name in dict.Keys)
    {
        Console.WriteLine($"There are {dict[name].Count} entries with name {name}:");
        foreach(var o in dict[name])
            Console.Write("    " + o.ToString());
    }
