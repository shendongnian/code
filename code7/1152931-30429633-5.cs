    static void Example(ref int value)
    {
        Console.WriteLine("Value is {0}", value);
        value = 99;
    }
    usage
    {
        int value = 10;
        Example(ref value); // Will print <Value is 10>
        Console.WriteLine("Value is {0}", value); // Will print <Value is 99>
    }
