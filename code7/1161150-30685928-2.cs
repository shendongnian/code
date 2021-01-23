    var comp = SyntaxFactory.CompilationUnit()
			.AddMembers(
				SyntaxFactory.NamespaceDeclaration(SyntaxFactory.IdentifierName("ACO"))
						.AddMembers(
						SyntaxFactory.ClassDeclaration("MainForm")
							.AddMembers(
								SyntaxFactory.PropertyDeclaration(SyntaxFactory.ParseTypeName("System.Windows.Forms.Timer"), "Ticker")
										.AddAccessorListAccessors(
										SyntaxFactory.AccessorDeclaration(SyntaxKind.GetAccessorDeclaration).WithSemicolonToken(SyntaxFactory.Token(SyntaxKind.SemicolonToken)),
										SyntaxFactory.AccessorDeclaration(SyntaxKind.SetAccessorDeclaration).WithSemicolonToken(SyntaxFactory.Token(SyntaxKind.SemicolonToken))),
								SyntaxFactory.MethodDeclaration(SyntaxFactory.ParseTypeName("void"), "Main")
										.AddModifiers(SyntaxFactory.Token(SyntaxKind.PublicKeyword))
										.WithBody(SyntaxFactory.Block())
								)
						)
				);
