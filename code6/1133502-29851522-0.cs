    var dt = DateTime.Now;
    var s = string.Empty;
    while ((DateTime.Now - dt).TotalSeconds < 5)
    {
        if (Console.KeyAvailable)
            s += Console.ReadKey().KeyChar;
    }
