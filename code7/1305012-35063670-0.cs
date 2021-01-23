    using Microsoft.CSharp;
    using System;
    using System.CodeDom.Compiler;
    using System.Collections.Generic;
    using System.Text;
    using System.Text.RegularExpressions;
    
    namespace ConsoleApplication
    {
        public class Program
        {
            public static string GenerateCode(Dictionary<string, int> dict, string expres)
            {
                var r = new Regex("[A-Z]");
                var res = "";
    
                foreach (var item in r.Matches(expres))
                { 
                    var key = item.ToString();
                    res += string.Format("var {0} = new Wrapper({1});\n", item, dict.ContainsKey(key) ? dict[key] : 0);
                }
    
                return string.Format("{0}return {1};", res, expres);            
            }
    
            public static bool GetAnswer(Dictionary<string, int> dict, string expres)
            {
                string code = @"
    using System;
    
        namespace First
        {
    
            public class Wrapper
            {
                public int value;
                public Wrapper(int val)
                {
                    value = val;
                }
                public static bool operator &(Wrapper c1, Wrapper c2)
                {
                    return c1.value > 0 && c2.value > 0;
                }
                public static bool operator |(Wrapper c1, Wrapper c2)
                {
                    return c1.value > 0 || c2.value > 0;
                }
                public static bool operator !(Wrapper c1)
                {
                    return c1.value <= 0;
                }
                public static implicit operator bool(Wrapper d)
                {
                    return d.value > 0;
                }
            }
    
            public class Program
            {
                public static bool Calculate()
                {
                " + GenerateCode(dict, expres) + @"
                }
    
                public static void Main()
                {  
                }
    
            }
        }";
                var provider = new CSharpCodeProvider();
                var parameters = new CompilerParameters();
    
                parameters.GenerateInMemory = true;
                parameters.GenerateExecutable = true;
    
                var results = provider.CompileAssemblyFromSource(parameters, code);
                if (results.Errors.HasErrors)
                {
                    var sb = new StringBuilder();
                    foreach (CompilerError error in results.Errors)
                        sb.AppendLine(String.Format("Error ({0}): {1}", error.ErrorNumber, error.ErrorText));
                    throw new InvalidOperationException(sb.ToString());
                }
                else
                {
                    var assembly = results.CompiledAssembly;
                    var program = assembly.GetType("First.Program");
                    var main = program.GetMethod("Calculate");
                    return (bool)main.Invoke(null, null);
                }
            }
    
            public static void Main()
            {            
                var dict = new Dictionary<string, int>();
                dict.Add("A", 1);
                dict.Add("B", 4);            
                dict.Add("D", 0);            
    
                Console.WriteLine(GetAnswer(dict, "(!A & B) | (C | (!D & F))"));  
            }
        }
    }
