    IEnumerable<INamedTypeSymbol> types =
        solution
        .Projects
        .SelectMany(project => project.Documents)
        .Select(document =>
            new
            {
                Model = document.GetSemanticModelAsync().Result,
                Declarations = document.GetSyntaxRootAsync().Result
                    .DescendantNodes().OfType<TypeDeclarationSyntax>()
            })
        .SelectMany(pair =>
            pair.Declarations.Select(declaration =>
                pair.Model.GetDeclaredSymbol(declaration) as INamedTypeSymbol));
