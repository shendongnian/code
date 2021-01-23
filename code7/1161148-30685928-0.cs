    var comp = CSharpCompilation
		.Create("danny")
		.AddSyntaxTrees(
			SyntaxFactory.SyntaxTree(
				SyntaxFactory
					.NamespaceDeclaration(SyntaxFactory.ParseName("Danny"))
					.WithMembers(
						SyntaxFactory.List<MemberDeclarationSyntax>(new[] {
							SyntaxFactory
								.ClassDeclaration("danny")
								.WithMembers(
									SyntaxFactory.List<MemberDeclarationSyntax>(new[] {
										SyntaxFactory.PropertyDeclaration(SyntaxFactory.ParseTypeName("string"), "fred")
									})
								)
						})
					)
			)
		);
