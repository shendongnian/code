    internal static void Execute()
    {
    	const string source = @"
    using System;
    
    class MyClass
    {
        void Method()
        {
            MyClass nameOfVariable, another;
        }
    }
    ";
    	var tree = CSharpSyntaxTree.ParseText(source);
    	var compilation = CSharpCompilation.Create("MyCompilation", new[] { tree }, new[] { MetadataReference.CreateFromFile(typeof(object).Assembly.Location) });
    	var semanticModel = compilation.GetSemanticModel(tree);
    	var root = tree.GetRoot();
    
    	var local = root.DescendantNodes().OfType<LocalDeclarationStatementSyntax>().First();
    	var method = local.Ancestors().OfType<MethodDeclarationSyntax>().First();
    
    	var variableIdentifier = SyntaxFactory.IdentifierName("nameOfVariable");
    	var classIdentifier = SyntaxFactory.IdentifierName("MyClass");
    	var objectCreationExpression = SyntaxFactory.ObjectCreationExpression(classIdentifier, SyntaxFactory.ArgumentList(), null);
    	var assignment = SyntaxFactory.AssignmentExpression(SyntaxKind.SimpleAssignmentExpression, variableIdentifier, objectCreationExpression);
    	var expressionStatement = SyntaxFactory.ExpressionStatement(assignment).WithAdditionalAnnotations(Formatter.Annotation);
    	var newMethod = method.AddBodyStatements(expressionStatement);
    
    	var newRoot = root.ReplaceNode(method.Body, newMethod.Body);
    	var formattedRoot = Formatter.Format(newRoot, Formatter.Annotation, new AdhocWorkspace());
    
    	Console.WriteLine(formattedRoot.GetText());
    	Console.Read();
    }
