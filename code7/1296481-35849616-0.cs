    using Microsoft.CodeAnalysis.CSharp;
    using Microsoft.CodeAnalysis.CSharp.Syntax;
        var t = CSharpSyntaxTree.ParseText(@"
            using System;
            namespace Muhterem
            {
                class Main
                {   
                    static void Main(string[] args)
                    {
                        Hello();
                    }
                    static void Hello()
                    {
                        Console.WriteLine();
                    }
                }   
                class Generic<T>
                {}
                abstract class AbstractClass
                {}
            }
            ");
            var roo = t.GetRoot();
            var classes = roo.DescendantNodes().OfType<ClassDeclarationSyntax>();
            foreach (var y in classes)
            {
                Console.WriteLine(y.Identifier);
            }
