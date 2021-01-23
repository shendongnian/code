    var tokens = docText.Split('\n')
        .Select(line => XmlTextLiteral(line))
        .ToList();
    for(int i = 1; i < tokens.Count; i += 2)
        tokens.Insert(i, XmlTextNewLine("\n"));
    
    var summary = XmlElement("summary",
        SingletonList<XmlNodeSyntax>(XmlText(TokenList(tokens))));
    SyntaxTriviaList doc = TriviaList(
        Trivia(DocumentationComment(summary, XmlText("\n"))));
    return member.WithLeadingTrivia(doc);
