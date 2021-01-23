    StringBuilder x = new StringBuilder();
    char b = '@';
    for (int i = 0; i < 10; ++i)
    {
        ++b;
        x.Append(b);
        Console.WriteLine(x); // Prints "A", then "AB", then "ABC" etc.
    }
