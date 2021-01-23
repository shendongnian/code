    using System;
    using System.CodeDom.Compiler;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Reflection;
    using Microsoft.CSharp;
    
    public class Program
    {
    
        static void Main()
        {
            String2LineOfCommand("P[0].ToString() + P[1].ToString()", 2, 4);
        }
    
        private static void String2LineOfCommand(string expresion1, params dynamic[] P)
        {
            MethodInfo function = CreateFunction(expresion1);
            object result = function.Invoke(null, new[] { P });
            Console.WriteLine(result.ToString());
            Debug.WriteLine(result.ToString());
        }
    
        public static MethodInfo CreateFunction(string function)
        {
            string code1 = @"
                            using System;
                            using System.Collections.Generic;
                            using System.Reflection;
                            using System.Dynamic;
    
                            namespace UserFunctions
                            {                
                                public class ParametricFunctions
                                {                
                                      public static object Function1(dynamic[] P)
                                      {
                                           return " + function + @";
                                      }
                                 }
                             }
                           ";
    
            var providerOptions = new Dictionary<string, string>();
            providerOptions.Add("CompilerVersion", "v4.0");
    
            CSharpCodeProvider provider = new CSharpCodeProvider(providerOptions);
            CompilerParameters cp = new CompilerParameters();
            cp.GenerateInMemory = true;
            cp.TreatWarningsAsErrors = false;
            cp.ReferencedAssemblies.Add("System.dll");
            cp.ReferencedAssemblies.Add("System.Core.dll");
            cp.ReferencedAssemblies.Add("System.Windows.dll");
            cp.ReferencedAssemblies.Add("System.Dynamic.dll");
            cp.ReferencedAssemblies.Add("Microsoft.CSharp.dll");
    
            CompilerResults results = provider.CompileAssemblyFromSource(cp, code1);
    
            Type parametricFunction1 = results.CompiledAssembly.GetType("UserFunctions.ParametricFunctions");
            return parametricFunction1.GetMethod("Function1");
        }
    }
