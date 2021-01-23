    foreach (var item in result)
    {
        Console.WriteLine(item.Col1);
        Console.WriteLine(item.Col2);
        Console.WriteLine(item.Col3);
        Console.WriteLine(item.Col4);
        Console.WriteLine(item.Col5);
        // If you want an array:
        var arr = new string[] { item.Col1, item.Col2, item.Col3, item.Col4, item.Col5 };
    }
