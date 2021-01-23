    var tree = CSharpSyntaxTree.ParseText(@"
    class MyClass
    {
        int firstVariable, secondVariable;
        string thirdVariable;
    }");
    var mscorlib = MetadataReference.CreateFromFile(typeof(object).Assembly.Location);
    var compilation = CSharpCompilation.Create("MyCompilation",
        syntaxTrees: new[] { tree }, references: new[] { mscorlib });
    var fields = tree.GetRoot().DescendantNodes().OfType<FieldDeclarationSyntax>();
    //Get a particular variable in a field
    var second = fields.SelectMany(n => n.Declaration.Variables).Where(n => n.Identifier.ValueText == "secondVariable").Single();
    //Get the type of both of the first two fields.
    var type = fields.First().Declaration.Type;
    //Get the third variable
    var third = fields.SelectMany(n => n.Declaration.Variables).Where(n => n.Identifier.ValueText == "thirdVariable").Single();
