    private static IEnumerable<string> FindUsedUsings(SemanticModel model, 
                SyntaxNode node, SyntaxNode root)
    {
        var aliasResolution = new Dictionary<string, string>();
        var usings = root.DescendantNodes().OfType<UsingDirectiveSyntax>();
        foreach (var curr in usings)
        {
            var nameEquals = curr.DescendantNodes().
                OfType<NameEqualsSyntax>().FirstOrDefault();
            if (nameEquals != null)
            {
                var qualifiedName =
                    curr.DescendantNodes().OfType<QualifiedNameSyntax>().
                        FirstOrDefault()?.ToFullString();
                if (qualifiedName != null)
                {
                    aliasResolution.Add(nameEquals.Name.Identifier.Text, qualifiedName);
                }
            }
        }
        var currentNamespace = node.Ancestors().
            OfType<NamespaceDeclarationSyntax>().FirstOrDefault();
        var namespacename = currentNamespace?.Name.ToString();
        if (namespacename == null)
        {
            // Empty namespace
            namespacename = string.Empty;
        }
        var resultList = new List<string>();
        foreach (var identifier in node.DescendantNodesAndSelf().OfType<TypeSyntax>())
        {
            if (identifier is PredefinedTypeSyntax || identifier.IsVar)
            {
                // No usings required for predefined types or var... 
                // [string, int, char, var, etc. do not need usings]
                continue;
            }
            // If an alias is defined use it prioritized
            if (GetUsingFromAlias(model, identifier, aliasResolution, resultList))
            {
                continue;
            }
            // If a type is provided, try to resolve it
            if (GetUsingFromType(model, identifier, namespacename, resultList))
            {
                continue;
            }
            // If no type is provided check if the expression 
            // corresponds to a static member call
            GetUsingFromStatic(model, identifier, resultList);
        }
        return resultList.Distinct().ToList();
    }
    private static void GetUsingFromStatic(SemanticModel model, TypeSyntax identifier, 
                List<string> resultList)
    {
        var symbol = model.GetSymbolInfo(identifier).Symbol;
        // If the symbol (field, property, method call) can be resolved, 
        // is static and has a containing type
        if (symbol != null && symbol.IsStatic && symbol.ContainingType != null)
        {
            var memberAccess = identifier.Parent as ExpressionSyntax;
            if (memberAccess != null)
            {
                bool hasCallingType = false;
                var children = memberAccess.ChildNodes();
                foreach (var childNode in children)
                {
                    // If the Expression has a Type 
                    // (that is, if the expression is called from an identifyable source)
                    // no using static is required
                    var typeInfo = model.GetSymbolInfo(childNode).Symbol as INamedTypeSymbol;
                    if (typeInfo != null)
                    {
                        hasCallingType = true;
                        break;
                    }
                }
                // if the type-Info is missing a static using is required
                if (!hasCallingType)
                {
                    // type three using: using static [QualifiedType]
                    resultList.Add($"static {symbol.ContainingType}");
                }
            }
        }
    }
    private static bool GetUsingFromType(SemanticModel model, TypeSyntax identifier, 
                string namespacename, List<string> resultList)
    {
        var typeInfo = model.GetSymbolInfo(identifier).Symbol as INamedTypeSymbol;
        // dynamic is not required and not provided as an INamedTypeSymbol
        if (typeInfo != null)
        {
            if (identifier is QualifiedNameSyntax 
                || identifier.Parent is QualifiedNameSyntax)
            {
                // Qualified namespaces can be ignored...
                return true;
            }
            var containingNamespace = typeInfo.ContainingNamespace.ToDisplayString();
            // The current namespace need not be referenced
            if (namespacename == containingNamespace)
            {
                return true;
            }
            // Type one using: using [Namespace];
            resultList.Add(typeInfo.ContainingNamespace.ToDisplayString());
            return true;
        }
        return false;
    }
    private static bool GetUsingFromAlias(SemanticModel model, TypeSyntax identifier, 
                Dictionary<string, string> aliasResolution, List<string> resultList)
    {
        var aliasInfo = model.GetAliasInfo(identifier);
        // If the identifier is an alias
        if (aliasInfo != null)
        {
            // check if it can be resolved
            if (aliasResolution.ContainsKey(aliasInfo.Name))
            {
                // Type two using: using [Alias] = [QualifiedType];
                resultList.Add($"{aliasInfo.Name} = {aliasResolution[aliasInfo.Name]}");
                return true;
            }
        }
        return false;
    }
