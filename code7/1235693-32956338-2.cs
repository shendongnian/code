    class IfStatementRewriter : CSharpSyntaxRewriter {
    
      public override SyntaxNode VisitIfStatement(IfStatementSyntax ifStatement) {
        var containsMagicString = ifStatement
          .Condition
          .DescendantNodes()
          .Any(
            syntaxNode => syntaxNode.ToString() == @"""somedumbstringbecausethisishorriblewayofdoingthings"""
          );
        if (!containsMagicString)
          // Do not modify if statement.
          return ifStatement;
        // Only look at the "true" part and assume it is a block (has curly braces).
        var block = ifStatement.Statement as BlockSyntax;
        if (block == null)
          // Do not modify if statement.
          return ifStatement;
        // Insert instrumentation code at start of block.
        var instrumentationStatements = CreateInstrumentationStatements("True branch");
        var modifiedStatements = block.Statements.InsertRange(0, instrumentationStatements);
        var modifiedBlock = block.WithStatements(modifiedStatements);
        return ifStatement.WithStatement(modifiedBlock);
      }
    
    }
