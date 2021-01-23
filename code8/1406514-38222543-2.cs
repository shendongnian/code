    // Create an auto-property
	var idProperty =
		SyntaxFactory.PropertyDeclaration(
			SyntaxFactory.ParseTypeName("Guid"),
			"Id"
		)
		.AddModifiers(SyntaxFactory.Token(SyntaxKind.PublicKeyword))
		.AddAccessorListAccessors(
			SyntaxFactory.AccessorDeclaration(SyntaxKind.GetAccessorDeclaration).WithSemicolonToken(SyntaxFactory.Token(SyntaxKind.SemicolonToken)),
			SyntaxFactory.AccessorDeclaration(SyntaxKind.SetAccessorDeclaration).WithSemicolonToken(SyntaxFactory.Token(SyntaxKind.SemicolonToken))
		);
    // Create a read-only property, using a backing field
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
