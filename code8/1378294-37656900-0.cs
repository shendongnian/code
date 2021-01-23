    List<ISymbol> ls = new List<ISymbol>();
    foreach (Document d in p.Documents)
    {
        SemanticModel m = d.GetSemanticModelAsync().Result;
        List<ClassDeclarationSyntax> lc = d.GetSyntaxRootAsync().Result.DescendantNodes().OfType<ClassDeclaractionSyntax>().ToList();
        foreach ( var c in lc )
        {
            ISymbol s =  m.GetDeclaredSymbol(c);
            ls.Add(s);
        }
    }
