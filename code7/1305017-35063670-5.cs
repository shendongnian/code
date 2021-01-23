    using Microsoft.CSharp;
    using System;
    using System.CodeDom.Compiler;
    using System.Collections.Generic;
    using System.Text;
    using System.Text.RegularExpressions;
    
    namespace ConsoleApplication5
    {
        public class Program
        {
            public static string GenerateCode(Dictionary<string, int> dict, string expres)
            {
                var r = new Regex(@"\d+");
                foreach (var item1 in r.Matches(expres))
                    expres = expres.Replace(item1.ToString(), string.Format("(new Wrapper({0}))", item1.ToString()));            
    
                r = new Regex("[A-Z]");
                var res = "";
                var areadyDone = new List<string>();
    
                foreach (var item in r.Matches(expres))
                {                 
                    var key = item.ToString();
                    if (!areadyDone.Contains(key))
                    {
                        res += string.Format("var {0} = new Wrapper({1});\n", item, dict.ContainsKey(key) ? dict[key].ToString() : "");
                        areadyDone.Add(key);
                    }
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
                public bool exist = false;
                public Wrapper(int value)
                {
                    this.value = value;
                    this.exist = true;
                }
                public Wrapper()
                {                
                }
                public static bool operator &(Wrapper c1, Wrapper c2)
                {
                    return c1.exist && c2.exist;
                }
                public static bool operator |(Wrapper c1, Wrapper c2)
                {
                    return c1.exist || c2.exist;
                }
                public static bool operator !(Wrapper c1)
                {
                    return !c1.exist;
                }
                public static implicit operator bool(Wrapper d)
                {
                    return d.exist;
                }
    
                public static bool operator >(Wrapper c1, Wrapper c2)
                {
                    return c1.value > c2.value;
                }
                public static bool operator <(Wrapper c1, Wrapper c2)
                {
                    return c1.value < c2.value;
                }
                public static bool operator ==(Wrapper c1, Wrapper c2)
                {
                    return c1.value == c2.value;
                }
                public static bool operator !=(Wrapper c1, Wrapper c2)
                {
                    return c1.value != c2.value;
                }
    
            public override bool Equals(object obj)
            {
                return base.Equals(obj);
            }
    
            public override int GetHashCode()
            {
                return base.GetHashCode();
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
                dict.Add("A", 23);
                dict.Add("B", 4);                        
                dict.Add("F", 5);
    
                Console.WriteLine(GetAnswer(dict, "((A == 22) & (F > 1)) | C"));  
            }
        }
    }
