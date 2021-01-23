    static void PrintType<T>(T value)
    {
        Console.WriteLine(typeof(T));
    }
    PrintType(x);  // Prints System.Nullable`1[System.Boolean]
