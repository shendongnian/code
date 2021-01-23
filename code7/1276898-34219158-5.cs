    public static void SomeMethod(string variableOne, int variableTwo, UInt64 variableThree)
    {
        var arguments = Arguments.Create(SomeMethod, variableOne, variableTwo, variableThree).Dump();
        
        Console.WriteLine(arguments.Argument1.Name + " = " + arguments.Argument1.Value);
        Console.WriteLine(arguments.Argument2.Name + " = " + arguments.Argument2.Value);
        Console.WriteLine(arguments.Argument3.Name + " = " + arguments.Argument3.Value);
    }
