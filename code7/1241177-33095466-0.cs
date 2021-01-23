    var tree = CSharpSyntaxTree.ParseText(@"
    using System;
    class MyBaseClass
    {
    }
    class MyClass : MyBaseClass {
      static void Main(string[] args) {
        Console.WriteLine(""Hello, World!"");
      }
    }");
    var Mscorlib = PortableExecutableReference.CreateFromAssembly(typeof(object).Assembly);
    var compilation = CSharpCompilation.Create("MyCompilation",
        syntaxTrees: new[] { tree }, references: new[] { Mscorlib });
    var model = compilation.GetSemanticModel(tree);
    var myClass = tree.GetRoot().DescendantNodes().OfType<ClassDeclarationSyntax>().Last();
    var myClassSymbol = model.GetDeclaredSymbol(myClass);
    var baseTypeName = myClassSymbol.BaseType.Name;
