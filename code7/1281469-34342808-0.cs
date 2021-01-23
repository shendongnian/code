    foreach (var line in list)
    {
        if (line.Contains("multiline"))
           Console.WriteLine("has A");
        else if (line.Contains("testing"))
           Console.WriteLine("has B");     
    }
