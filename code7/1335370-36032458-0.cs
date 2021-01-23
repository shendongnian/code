        public static async Task GetNameFromDocument(Document document)
        {
            var syntaxTree = await document.GetSyntaxTreeAsync();
            var semanticModel = await document.GetSemanticModelAsync();
            var root = syntaxTree.GetRoot();
            MemberAccessExpressionSyntax member = GetMemberAccessExpressionSyntax(root);
            if (member != null)
            {
                var firstChild = member.ChildNodes().ElementAt(0);
                var typeInfo = semanticModel.GetTypeInfo(firstChild).Type as INamedTypeSymbol;
                var typeName = typeInfo.Name;
            }
        }
        public static MemberAccessExpressionSyntax GetMemberAccessExpressionSyntax(SyntaxNode node)
        {
            return node.DescendantNodes().Where(curr => curr is MemberAccessExpressionSyntax)
                .ToList().FirstOrDefault() as MemberAccessExpressionSyntax;
        }
		
