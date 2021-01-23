    string x = "";
    char b = '@';
    for (int i = 0; i < 10; ++i)
    {
        ++b;
        x += b;
        Console.WriteLine(x); // Prints "A", then "AB", then "ABC" etc.
    }
