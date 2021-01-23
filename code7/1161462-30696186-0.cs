            SyntaxFactory.ClassDeclaration(
                @"C")
            .WithKeyword(
                SyntaxFactory.Token(
                    SyntaxFactory.TriviaList(
                        SyntaxFactory.Trivia(
                            SyntaxFactory.DocumentationCommentTrivia(
                                SyntaxKind.SingleLineDocumentationCommentTrivia,
                                SyntaxFactory.List<XmlNodeSyntax>(
                                    new XmlNodeSyntax[]{
                                        SyntaxFactory.XmlText()
                                        .WithTextTokens(
                                            SyntaxFactory.TokenList(
                                                SyntaxFactory.XmlTextLiteral(
                                                    SyntaxFactory.TriviaList(
                                                        SyntaxFactory.DocumentationCommentExterior(
                                                            @"///")),
                                                    @" ",
                                                    @" ",
                                                    SyntaxFactory.TriviaList()))),
                                        SyntaxFactory.XmlElement(
                                            SyntaxFactory.XmlElementStartTag(
                                                SyntaxFactory.XmlName(
                                                    SyntaxFactory.Identifier(
                                                        @"summary"))),
                                            SyntaxFactory.XmlElementEndTag(
                                                SyntaxFactory.XmlName(
                                                    SyntaxFactory.Identifier(
                                                        @"summary"))))
                                        .WithContent(
                                            SyntaxFactory.SingletonList<XmlNodeSyntax>(
                                                SyntaxFactory.XmlText()
                                                .WithTextTokens(
                                                    SyntaxFactory.TokenList(
                                                        new []{
                                                            SyntaxFactory.XmlTextNewLine(
                                                                SyntaxFactory.TriviaList(),
                                                                @"
    ",
                                                                @"
    ",
                                                                SyntaxFactory.TriviaList()),
                                                            SyntaxFactory.XmlTextLiteral(
                                                                SyntaxFactory.TriviaList(
                                                                    SyntaxFactory.DocumentationCommentExterior(
                                                                        @"///")),
                                                                @" Some plain text here.",
                                                                @" Some plain text here.",
                                                                SyntaxFactory.TriviaList()),
                                                            SyntaxFactory.XmlTextNewLine(
                                                                SyntaxFactory.TriviaList(),
                                                                @"
    ",
                                                                @"
    ",
                                                                SyntaxFactory.TriviaList()),
                                                            SyntaxFactory.XmlTextLiteral(
                                                                SyntaxFactory.TriviaList(
                                                                    SyntaxFactory.DocumentationCommentExterior(
                                                                        @"///")),
                                                                @" ",
                                                                @" ",
                                                                SyntaxFactory.TriviaList())})))),
                                        SyntaxFactory.XmlText()
                                        .WithTextTokens(
                                            SyntaxFactory.TokenList(
                                                SyntaxFactory.XmlTextNewLine(
                                                    SyntaxFactory.TriviaList(),
                                                    @"
    ",
                                                    @"
    ",
                                                    SyntaxFactory.TriviaList())))})))),
                    SyntaxKind.ClassKeyword,
                    SyntaxFactory.TriviaList()))))
