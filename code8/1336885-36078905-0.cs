      IfStatementSyntax originalIfStatement = parentIfStatement;
      root = root.TrackNodes(originalParentIfStatement);
      parentIfStatement = root.GetCurrentNode(originalParentIfStatement);
      root = root.InsertNodesBefore(parentIfStatement, new[] { SyntaxFactory.ExpressionStatement(newExpression) });
      parentIfStatement = root.GetCurrentNode(originalParentIfStatement);
      root = root.RemoveNode(parentIfStatement, SyntaxRemoveOptions.KeepNoTrivia);
