    using System;
    using System.IO;
    using Microsoft.CodeAnalysis;
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
                
                var syntax_tree = CSharpSyntaxTree.ParseText(program_text);
    
                var compilation = CSharpCompilation.Create(
                    Guid.NewGuid().ToString("D"),
                    new[] { syntax_tree },
                    new[] { MetadataReference.CreateFromFile(@"C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.5.2\mscorlib.dll") });
    
                var emit_result = compilation.Emit(new MemoryStream());
            }
        }
    }
