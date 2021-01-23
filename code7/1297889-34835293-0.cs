    internal static bool HasBackingField(this PropertyDeclarationSyntax property)
    {
    	var getter = property.AccessorList?.Accessors.FirstOrDefault(x => x.IsKind(SyntaxKind.GetAccessorDeclaration));
    	var setter = property.AccessorList?.Accessors.FirstOrDefault(x => x.IsKind(SyntaxKind.SetAccessorDeclaration));
       
    	if (setter?.Body == null || getter?.Body == null)
    	{
    		return false;
    	}
    
    	bool setterHasBodyStatements = setter.Body.Statements.Any();
    	bool getterHasBodyStatements = getter.Body.Statements.Any();
    
    	return setterHasBodyStatements && getterHasBodyStatements;
    }
