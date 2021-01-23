    syncInterface
      .ReplaceNodes(
          syncInterface.Members.OfType<MethodDeclarationSyntax>(),
          (a, b) =>
              b.WithReturnType(
                  SyntaxFactory.GenericName("Task").AddTypeArgumentListArguments(b.ReturnType)))
      .NormalizeWhitespace();
