    public override SyntaxNode VisitMethodDeclaration(MethodDeclarationSyntax node)
    {
        var semanticModel = _compilation.GetSemanticModel(node.SyntaxTree);
        // semanticModel.AnalyzeControlFlow(node.Block)
        return node;
    }
