    Console.WriteLine((sbyte)s[0, 0]);
    Console.WriteLine((sbyte)State.BUG);
    Console.WriteLine(s[0, 0]);
    unchecked
    {
        Console.WriteLine((byte) State.BUG);
    }
