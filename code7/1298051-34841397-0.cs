    using System.CodeDom.Compiler;
    using System.Reflection;
    using Microsoft.CSharp;
    public static class RuntimeHelpers
    {
        public static MethodInfo CreateFunction()
        {
            //You can pass it through parameter
            string code = @"
                using System;
            
                namespace RuntimeFunctions
                {                
                    public class Functions
                    {                
                        public static void PrintStuff(string input)
                        {
                            Console.WriteLine(input);
                        }
                    }
                }";
            //Compile on runtime:
            CSharpCodeProvider provider = new CSharpCodeProvider();
            CompilerResults results = provider.CompileAssemblyFromSource(new CompilerParameters(), code);
            //Compiled code threw error? Print it.
            if (results.Errors.HasErrors)
            {
                foreach (var error in results.Errors)
                {
                    Console.WriteLine(error);
                }
            }
            
            //Return MethodInfo for future use
            Type function = results.CompiledAssembly.GetType("RuntimeFunctions.Functions");
            return function.GetMethod("PrintStuff");
        }
    }
