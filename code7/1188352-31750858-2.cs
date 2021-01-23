    #region User Check
    Console.Write("User: {0} ... ", Environment.UserName);
    if (validUser(Environment.UserName).Equals(false))
    {
        ColoredConsoleWrite(ConsoleColor.Red, "BAD!");
        Console.WriteLine(" - Making like a tree, and getting out of here!");
        Environment.Exit(0);
    }
    ColoredConsoleWrite(ConsoleColor.Green, "GOOD!"); Console.WriteLine(" - Continue on!");
    #endregion
