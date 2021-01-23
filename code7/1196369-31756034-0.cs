	public class AttributeRemoverRewriter : CSharpSyntaxRewriter
	{
		public override SyntaxNode VisitMethodDeclaration(MethodDeclarationSyntax node)
		{
			var newAttributes = new SyntaxList<AttributeListSyntax>();
			foreach (var attributeList in node.AttributeLists)
			{
				var nodesToRemove =
				attributeList
			   .Attributes
			   .Where(att => (att.Name as IdentifierNameSyntax).Identifier.Text.StartsWith("TestCategory"))
			   .ToArray();
				if (nodesToRemove.Length == attributeList.Attributes.Count)
				{
					//Do not add the attribute to the list. It's being removed completely.
				}
				else
				{
                    //We want to remove only some of the attributes
					var newAttribute = (AttributeListSyntax)VisitAttributeList(attributeList.RemoveNodes(nodesToRemove, SyntaxRemoveOptions.KeepNoTrivia));
					newAttributes = newAttributes.Add(newAttribute);
				}
			}
			//Get the leading trivia (the newlines and comments)
			var leadTriv = node.GetLeadingTrivia();
			node = node.WithAttributeLists(newAttributes);
			//Append the leading trivia to the method
			node = node.WithLeadingTrivia(leadTriv);
			return node;
		}
	}
