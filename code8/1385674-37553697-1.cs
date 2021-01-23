    var tree = SyntaxFactory.ParseSyntaxTree(
    @"class MyClass
    {
        #region myRegion
        #endregion
    }");
    
    // get the region trivia
    var region = tree.GetRoot()
        .DescendantNodes(descendIntoTrivia: true)
        .OfType<RegionDirectiveTriviaSyntax>()
        .Single();
    
    // modify the source text
    tree = tree.WithChangedText(
        tree.GetText().WithChanges(
            new TextChange(
                region.GetLocation().SourceSpan,
                region.ToFullString() + "private const string myData = \"somedata\";")));
