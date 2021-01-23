    public async override Task RegisterCodeFixesAsync(CodeFixContext context)
    {
        var document = context.Document;
        var cancellationToken = context.CancellationToken;
        var span = context.Span;
        var diagnostics = context.Diagnostics;
        var root = await document.GetSyntaxRootAsync(cancellationToken);
        var diagnostic = diagnostics.First();
        var assignmentExpression = root.FindNode(context.Span) as AssignmentExpressionSyntax;
        var objectCreation = assignmentExpression?.Right as ObjectCreationExpressionSyntax;
        var argument = objectCreation?.ArgumentList.Arguments[0];
        if (argument == null)
            return;
       
       var identifier = argument.DescendantNodes()
                        .OfType<IdentifierNameSyntax>).First();
       var newRoot = root.ReplaceNode(objectCreation,
               SyntaxFactory.IdentifierName(identifier.Identifier.Text)); 
    context.RegisterCodeFix(CodeActionFactory.Create(assignmentExpression.Span, diagnostic.Severity, "Remove redundant 'new'", document.WithSyntaxRoot(newRoot)), diagnostic);
    }
