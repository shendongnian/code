    static void Example(out int value)
    {
        value = 99;
        Console.WriteLine("Value is {0}", value);
    }
    usage
    {
        int value; // no need to init it
        Example(out value); // Will print <Value is 99>
        Console.WriteLine("Value is {0}", value); // Will print <Value is 99>
    }
