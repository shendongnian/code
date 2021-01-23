    foreach (string productKey in items.Keys)
    {
        Console.WriteLine("Product: ", productKey);
        foreach (string item in items[productKey])
        {
            Console.Write("\t", item);
        }
        Console.WriteLine();
    }
