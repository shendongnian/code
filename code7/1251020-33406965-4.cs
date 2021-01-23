    using System.CodeDom.Compiler;
    using Microsoft.CSharp;
    //...
    private static void Main()
    {
        string Tempreture = "20 > 13 && 20 < 18";
        bool? result = Evaluate(Tempreture);
        if (!result.HasValue)
        {
            throw new ApplicationException("invalid expression.");
        }
        else if (result.Value)
        {
            //...
        }
        else
        {
            //...
        }
    }
    public static bool Evaluate(string condition)
    {
        // code to compile.
        const string conditionCode = "namespace Condition {{public class Program{{public static bool Main(){{ return {0};}}}}}}";
        // compile code.
        var cr = new CSharpCodeProvider().CompileAssemblyFromSource(
            new CompilerParameters { GenerateInMemory = true }, string.Format(conditionCode, condition));
         if (cr.Errors.HasErrors) return null;
        // get the method and invoke.
        var method = cr.CompiledAssembly.GetType("Condition.Program").GetMethod("Main");
        return (bool)method.Invoke(null, null);
    }
