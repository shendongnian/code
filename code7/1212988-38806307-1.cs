            public static IEnumerable<BaseTypeDeclarationSyntax>
                  FindClassesDerivedOrImplementedByType(Compilation compilation
            , INamedTypeSymbol target)
        {
            foreach (var tree in compilation.SyntaxTrees)
            {
                var semanticModel = compilation.GetSemanticModel(tree);
                foreach (var type in tree.GetRoot().DescendantNodes()
                            .OfType<TypeDeclarationSyntax>())
                {
                    var baseClasses = GetBaseClasses(semanticModel, type);
                    if (baseClasses != null)
                        if (baseClasses.Contains(target))
                            yield return type;
                }
            } 
        }
