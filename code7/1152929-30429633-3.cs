    static void Example(int value)
    {
        Console.WriteLine("Value is {0}", value);
        value = 99;
    }
    usage
    {
        int value = 10;
        Example(notADefaultValue); // Will print <Value is 10>
        Console.WriteLine("Value is {0}", value); // will print <Value is 10>
    }
