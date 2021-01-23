    var cu = Syntax.CompilationUnit()
                .AddMembers(
                    Syntax.NamespaceDeclaration(Syntax.IdentifierName("ACO"))
                            .AddMembers(
                            Syntax.ClassDeclaration("MainForm")
                                .AddBaseListTypes(Syntax.ParseTypeName("System.Windows.Forms.Form"))
                                .WithModifiers(Syntax.Token(SyntaxKind.PublicKeyword))
                                .AddMembers(
                                    Syntax.PropertyDeclaration(Syntax.ParseTypeName("System.Windows.Forms.Timer"), "Ticker")
                                            .AddAccessorListAccessors(
                                            Syntax.AccessorDeclaration(SyntaxKind.GetAccessorDeclaration).WithSemicolonToken(Syntax.Token(SyntaxKind.SemicolonToken)),
                                            Syntax.AccessorDeclaration(SyntaxKind.SetAccessorDeclaration).WithSemicolonToken(Syntax.Token(SyntaxKind.SemicolonToken))),
                                    Syntax.MethodDeclaration(Syntax.ParseTypeName("void"), "Main")
                                            .AddModifiers(Syntax.Token(SyntaxKind.PublicKeyword))
                                            .AddAttributes(Syntax.AttributeDeclaration().AddAttributes(Syntax.Attribute(Syntax.IdentifierName("STAThread"))))
                                            .WithBody(Syntax.Block())
                                    )
                            )
                    );
