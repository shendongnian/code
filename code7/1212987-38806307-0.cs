    public static IEnumerable<INamedTypeSymbol> GetBaseClasses(SemanticModel model, BaseTypeDeclarationSyntax type)
        {
            var classSymbol = model.GetDeclaredSymbol(type);
            var returnValue = new List<INamedTypeSymbol>();
            while (classSymbol.BaseType != null)
            {
                returnValue.Add(classSymbol.BaseType);
                if (classSymbol.Interfaces != null)
                returnValue.AddRange(classSymbol.Interfaces);
                classSymbol = classSymbol.BaseType;
            }
            return returnValue;
        }
