    foreach (var p in sourcePI)
    {
        Console.WriteLine(p.Name);
        var nested = p.GetValue(CurrentViewModel).GetType().GetProperties();
        foreach (var n in nested)
        {
            WriteLine(n.Name);
            // you can continue to nest as you like
        }
    }
