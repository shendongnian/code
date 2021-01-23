    var tree = CSharpSyntaxTree.ParseText(@"
    class MyClass
    {
        int firstVariable, secondVariable;
        string thirdVariable;
    }");
    var mscorlib = MetadataReference.CreateFromFile(typeof(object).Assembly.Location);
    var compilation = CSharpCompilation.Create("MyCompilation",
        syntaxTrees: new[] { tree }, references: new[] { mscorlib });
    //Get the semantic model
    //You can also get it from Documents
    var model = compilation.GetSemanticModel(tree);
    var fields = tree.GetRoot().DescendantNodes().OfType<FieldDeclarationSyntax>();
    var declarations = fields.Select(n => n.Declaration.Type);
    foreach (var type in declarations)
    {
        var typeSymbol = model.GetSymbolInfo(type).Symbol as INamedTypeSymbol;
        var fullName = typeSymbol.ToString();
        //Some types like int are special:
        var specialType = typeSymbol.SpecialType;
    }
