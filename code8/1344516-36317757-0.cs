    public static Tuple<UnionCaseInfo, object[]> TestIt()
    {
        var option = new FSharpOption<int>(123);
        MethodInfo method;
        try
        {
            // If "4.4.0.0" is loaded at runtime, get directly
            var t = typeof(FSharpValue);
            method = t.GetRuntimeMethods().First(mi => mi.Name == "GetUnionFields");
        }
        catch 
        {
            var t = typeof(FSharpReflectionExtensions);
            method = t.GetRuntimeMethods().First(mi => mi.Name == "FSharp.Value.GetUnionFields.Static");
        }
        return (Tuple<UnionCaseInfo, object[]>)method.Invoke(null, new object[] { option, option.GetType(), null });
    }
