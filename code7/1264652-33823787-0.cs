    if (t.IsGenericType && t.GetGenericTypeDefinition() == typeof(List<>))
    {
        Type elementType = t.GetGenericArguments()[0];
        if (elementType.IsGenericType && elementType.GetGenericTypeDefinition() == typeof(List<>))
            Console.WriteLine("t is a list of lists");
        else
            Console.WriteLine("t is just a list");
    }
    else
        Console.WriteLine("t is not a list");
