        protected static bool IsWebPage(SyntaxNodeAnalysisContext context, ClassDeclarationSyntax classDeclaration)
        {
            INamedTypeSymbol iSymbol = context.SemanticModel.GetDeclaredSymbol(classDeclaration) as INamedTypeSymbol;
            INamedTypeSymbol symbolBaseType = iSymbol?.BaseType;
            while (symbolBaseType != null)
            {
                if (symbolBaseType.ToString() == "System.Web.UI.Page")
                    return true;
                symbolBaseType = symbolBaseType.BaseType;
            }
            return false;
        }
