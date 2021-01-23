    SyntaxGenerator synGen = editor.Generator;
    foreach (StatementSyntax statement in blockNode.Statements)
    {
        if (statement.IsKind(SyntaxKind.IfStatement))
        {
            IfStatementSyntax ifs = statement as IfStatementSyntax;
            SyntaxList<StatementSyntax> trueStatements = new SyntaxList<StatementSyntax>();
            SyntaxList<StatementSyntax> falseStatements = new SyntaxList<StatementSyntax>();
            BlockSyntax ifBlock = ifs.ChildNodes().OfType<BlockSyntax>().FirstOrDefault();
            if (ifBlock != null)
            {
                ReturnStatementSyntax newRSS = ifBlock.ChildNodes().OfType<ReturnStatementSyntax>().FirstOrDefault();
                SyntaxList<StatementSyntax> ifStatements = ifBlock.Statements;
                foreach (StatementSyntax ss in ifStatements)
                {
                    if (ss.Kind() != SyntaxKind.ReturnStatement)
                    {
                        trueStatements = trueStatements.Add(ss);
                    }
                 }
                 foreach (StatementSyntax ss in newExitCode)
                 {
                     trueStatements = trueStatements.Add(ss);
                 }
                 trueStatements = trueStatements.Add(newRSS);
                 ElseClauseSyntax elseBlock = ifs.ChildNodes().OfType<ElseClauseSyntax>().FirstOrDefault();
                 if (elseBlock != null)
                 {
                     BlockSyntax block = elseBlock.ChildNodes().OfType<BlockSyntax>().FirstOrDefault();
                     if (block != null)
                     {
                         ReturnStatementSyntax newRSS = block.ChildNodes().OfType<ReturnStatementSyntax>().FirstOrDefault();
                         SyntaxList<StatementSyntax> elseStatements = block.Statements;
                         foreach (StatementSyntax ss in elseStatements)
                         {
                             if (ss.Kind() != SyntaxKind.ReturnStatement)
                             {
                                 falseStatements = falseStatements.Add(ss);
                             }
                         }
                         foreach (StatementSyntax ss in newExitCode)
                         {
                             falseStatements = falseStatements.Add(ss);
                         }
                         falseStatements = falseStatements.Add(newRSS);
                     }
                 }
                 IfStatementSyntax newIfStatement = (IfStatementSyntax)synGen.IfStatement(ifs.Condition, trueStatements, falseStatements);
                 newBlock = newBlock.Add(newIfStatement);
            }
            else
            {
                if (!statement.IsKind(SyntaxKind.ReturnStatement))
                {
                    newBlock = newBlock.Add(statement);
                }
                else
                {
                    newBlock = newBlock.AddRange(newExitCode);
                    newBlock = newBlock.Add(statement);
                }
            }
        }
    }
    var newBody = SyntaxFactory.Block(SyntaxFactory.Token(SyntaxKind.OpenBraceToken), newBlock, SyntaxFactory.Token(SyntaxKind.CloseBraceToken));
    var newMethod = SyntaxFactory.MethodDeclaration(mds.AttributeLists, mds.Modifiers, mds.ReturnType, mds.ExplicitInterfaceSpecifier, mds.Identifier, mds.TypeParameterList, mds.ParameterList, mds.ConstraintClauses, newBody, mds.ExpressionBody);
    editor.ReplaceNode(mds, newMethod);
    SyntaxNode newRoot = editor.GetChangedRoot();
    var newFormattedRoot = Formatter.Format(newRoot, Workspace);
    Document newDoc = editor.GetChangedDocument();
    doc = doc.WithSyntaxRoot(newFormattedRoot);
    methodsChanged++;
