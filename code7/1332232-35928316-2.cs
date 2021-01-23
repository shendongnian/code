	var attributeArgument = SyntaxFactory.AttributeArgument(
		SyntaxFactory.LiteralExpression(SyntaxKind.StringLiteralExpression, SyntaxFactory.Token(default(SyntaxTriviaList), SyntaxKind.StringLiteralToken, "some_param", "some_param", default(SyntaxTriviaList))));
	var otherList = new SeparatedSyntaxList<AttributeArgumentSyntax>();
	otherList = otherList.Add(attributeArgument);
	var argumentList = SyntaxFactory.AttributeArgumentList(otherList);
	var attribute2 = SyntaxFactory.Attribute(name, argumentList);
