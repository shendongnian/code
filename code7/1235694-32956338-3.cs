    IEnumerable<StatementSyntax> CreateInstrumentationStatements(String text) {
      return SyntaxFactory.SingletonList<StatementSyntax>(
        SyntaxFactory.ExpressionStatement(
          SyntaxFactory.InvocationExpression(
            SyntaxFactory.MemberAccessExpression(
              SyntaxKind.SimpleMemberAccessExpression,
              SyntaxFactory.MemberAccessExpression(
                SyntaxKind.SimpleMemberAccessExpression,
                SyntaxFactory.IdentifierName("System"),
                SyntaxFactory.IdentifierName("Console")
              )
              .WithOperatorToken(SyntaxFactory.Token(SyntaxKind.DotToken)),
              SyntaxFactory.IdentifierName("WriteLine")
            )
            .WithOperatorToken(SyntaxFactory.Token(SyntaxKind.DotToken))
          )
          .WithArgumentList(
            SyntaxFactory.ArgumentList(
              SyntaxFactory.SeparatedList(
                new[] {
                  SyntaxFactory.Argument(
                    SyntaxFactory.LiteralExpression(
                      SyntaxKind.StringLiteralExpression,
                      SyntaxFactory.Literal(text)
                    )
                  )
                }
              )
            )
          )
        )
        .WithSemicolonToken(SyntaxFactory.Token(SyntaxKind.SemicolonToken))
      );
    }
