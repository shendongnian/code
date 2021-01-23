    using Microsoft.CodeAnalysis.CSharp.Scripting;
    using System;
    
    namespace ExpressionParser
    {
        class Program
        {
            static void Main(string[] args)
            {
                //Demonstrate evaluating C# code
                var result = CSharpScript.EvaluateAsync("System.DateTime.Now.AddDays(-1) > System.DateTime.Now").Result;
                Console.WriteLine(result.ToString());
    
                //Demonstrate evaluating simple expressions
                var result2 = CSharpScript.EvaluateAsync(" 5 * 7").Result;
                Console.WriteLine(result2);
                Console.ReadKey();
            }
        }
    }
