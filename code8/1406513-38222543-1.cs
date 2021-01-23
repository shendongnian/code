	var idProperty =
		SyntaxFactory.PropertyDeclaration(
			SyntaxFactory.ParseTypeName("Guid"),
			"Id"
		)
		.AddModifiers(SyntaxFactory.Token(SyntaxKind.PublicKeyword))
		.AddAccessorListAccessors(
			SyntaxFactory.AccessorDeclaration(
				SyntaxKind.GetAccessorDeclaration,
				SyntaxFactory.Block(
					SyntaxFactory.List(new[] {
						SyntaxFactory.ReturnStatement(SyntaxFactory.IdentifierName("_id"))
					})
				)
			)
		);
	var createdAtProperty =
		SyntaxFactory.PropertyDeclaration(
			SyntaxFactory.ParseTypeName("DateTime"),
			"CreatedAt"
		)
		.AddModifiers(SyntaxFactory.Token(SyntaxKind.PublicKeyword))
		.AddAccessorListAccessors(
			SyntaxFactory.AccessorDeclaration(
				SyntaxKind.GetAccessorDeclaration,
				SyntaxFactory.Block(
					SyntaxFactory.List(new[] {
						SyntaxFactory.ReturnStatement(SyntaxFactory.IdentifierName("_createdAt"))
					})
				)
			)
		);
