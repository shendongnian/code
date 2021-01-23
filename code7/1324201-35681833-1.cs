    static void Main(string[] args)
    {
        string str = "6 < 5 ? 1002 * 2.5: 6 < 10 ? 1002 * 3.5: 1002 * 4";
    
        Console.WriteLine(EvaluateExpression(str));
        Console.ReadKey();
    }
    
    public static object EvaluateExpression(string expression)
    {
        var csc = new CSharpCodeProvider();
        var parameters = new CompilerParameters(new[] { "mscorlib.dll", "System.Core.dll" });
        parameters.GenerateExecutable = false;
        CompilerResults results = csc.CompileAssemblyFromSource(new CompilerParameters(new[] { "System.Core.dll" }),
            @"using System;
    
            class Program
            {
                public static object GetExpressionValue()
                {
                    return " + expression + @";
                }
            }");
    
        if (results.Errors.Count == 0)
        {
            return results.CompiledAssembly.GetType("Program").GetMethod("GetExpressionValue").Invoke(null, null);
        }
        else
        {
            return string.Format("Error while evaluating expression: {0}", string.Join(Environment.NewLine, results.Errors.OfType<CompilerError>()));
        }
    }
