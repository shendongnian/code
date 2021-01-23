    public static void SomeMethod(string variableOne, int variableTwo, UInt64 variableThree)
    {
        var arguments = Arguments.Create(variableOne, variableTwo, variableThree);
        Console.WriteLine(arguments.Argument1);
        Console.WriteLine(arguments.Argument2);
        Console.WriteLine(arguments.Argument3);
    }
