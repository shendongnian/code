    // List<Dictionary<string, List<Type>>>
    TypeSyntaxFactory.GetTypeSyntax(
        "List",
        TypeSyntaxFactory.GetTypeSyntax(
            "Dictionary",
            TypeSyntaxFactory.GetTypeSyntax(
                "string"
            ),
            TypeSyntaxFactory.GetTypeSyntax(
                "List",
                "Type"
            )
        )
    )
