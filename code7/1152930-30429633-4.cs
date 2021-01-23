    static void Example(int value = 5)
    {
        Console.WriteLine("Value is {0}", value);
    }
    usage
    {
        int notADefaultValue = 10;
        Example(notADefaultValue); // Will print <Value is 10>
        Example(); // will print <Value is 5>
    }
