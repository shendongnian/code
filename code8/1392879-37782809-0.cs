    bool IsParameter(IdentifierNameSyntax name)
    {
        SyntaxNode node = name;
        while (node != null && !(node is MethodDeclarationSyntax))
        {
            node = node.Parent;
        }
    
        var method = node as MethodDeclarationSyntax;
        if (method != null)
        {
            return method
                .ParameterList
                .Parameters
                .Any(p => p.Identifier.Text.Equals(name.Identifier.Text));
        }
    
        return false;            
    }
