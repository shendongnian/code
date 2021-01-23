    public static void SomeMethod(string variableOne, int variableTwo, UInt64 variableThree)
    {
        var arguments = new MethodArguments(variableOne, variableTwo, variableThree);
        foreach (var argument in arguments.Arguments)
        {
            Console.WriteLine(argument.Name + " (" + argument.Type.Name + ") = " + argument.Value);
        }
    }
