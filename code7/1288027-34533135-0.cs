    const string source = @"
    using System;
    
    class MyClass
    {
        void Method()
        {
            MyClass nameOfVariable;
        }
    }
    ";
    var tree = CSharpSyntaxTree.ParseText(source);
    var compilation = CSharpCompilation.Create("MyCompilation", new[] { tree }, new[] { MetadataReference.CreateFromFile(typeof(object).Assembly.Location) });
    var semanticModel = compilation.GetSemanticModel(tree);
    var root = tree.GetRoot();
    
    var local = root.DescendantNodes().OfType<LocalDeclarationStatementSyntax>().First();
    var declaration = local.Declaration;
    var declarator = declaration.Variables.First();
    
    var identifier = SyntaxFactory.IdentifierName("MyClass");
    var objectCreationExpression = SyntaxFactory.ObjectCreationExpression(identifier, SyntaxFactory.ArgumentList(), null);
    var equalsValueClause = SyntaxFactory.EqualsValueClause(objectCreationExpression);
    var newDeclarator = declarator.WithInitializer(equalsValueClause).WithAdditionalAnnotations(Formatter.Annotation);
    var newRoot = root.ReplaceNode(declarator, newDeclarator);
    var formattedRoot = Formatter.Format(newRoot, Formatter.Annotation, new AdhocWorkspace());
    
    Console.WriteLine(formattedRoot.GetText());
    Console.Read();
