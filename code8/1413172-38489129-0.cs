    public static MethodDeclarationSyntax getChangedNode(MethodDeclarationSyntax newmethod)
    {
    	/* Adding __tst.AddElement(i); */
    	while (true)
    	{
    		var desc = newmethod.Body.DescendantTrivia().Where((t) => t.IsKind(SyntaxKind.SingleLineDocumentationCommentTrivia));
    		var triviaFound = false;
    
    		foreach (var s in desc)
    		{
    			var commentContents = s.ToString();
    			char[] delim = { ' ', '\n', '\t', '\r' };
    			var ar = commentContents.Split(delim, StringSplitOptions.RemoveEmptyEntries);
    			if (ar.Length != 2 || ar[0] != "add") continue;
    
    			var lineToAdd = "\r\n__tst.AddElement(" + ar[1] + ");\r\n";
    			newmethod = CSharpSyntaxTree.ParseText(newmethod.GetText().Replace(s.FullSpan, lineToAdd))
    				.GetRoot().DescendantNodes().OfType<MethodDeclarationSyntax>().First();
    			triviaFound = true;
    			break;
    		}
    		if (!triviaFound) break;
    	}
    	return newmethod;
    }
