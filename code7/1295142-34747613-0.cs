    const string source = @"
    using System;
    
    namespace MyNamespace 
    {
        class MyClass : IDisposable
        {
            void Method()
            {
                MyClass nameOfVariable, another;
            }
        }
    }
    ";
    var tree = CSharpSyntaxTree.ParseText(source);
    var compilation = CSharpCompilation.Create("MyCompilation", new[] { tree }, new[] { MetadataReference.CreateFromFile(typeof(object).Assembly.Location) });
    var semanticModel = compilation.GetSemanticModel(tree);
    var root = tree.GetRoot();
    
    var classSymbol = semanticModel.GetDeclaredSymbol(root.DescendantNodes().OfType<ClassDeclarationSyntax>().First());
    Console.WriteLine(string.Join(", ", classSymbol.AllInterfaces));
