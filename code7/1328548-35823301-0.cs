    using Microsoft.CodeAnalysis.CSharp;
    
    namespace TestCompiler
    {
        class Program
        {
            static void Main(string[] args)
            {
                var program_text = @"
    
                    using System;
    
                    namespace ConsoleApplication2
                    {
                        class Program
                        {
                            static void Main(string[] args) 
                            { var result = 2 + 3; Console.WriteLine(result); }
                        }
                    }
                ";
    
                var result = CSharpSyntaxTree.ParseText(program_text);
            }
        }
    }
