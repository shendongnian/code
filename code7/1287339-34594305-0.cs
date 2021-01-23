	String Stringify(INode node)
	{
		switch (node.NodeType)
		{
			case NodeType.Text:
				return node.TextContent;
			case NodeType.Element:
				if (node.HasChildNodes)
				{
					var sb = new StringBuilder();
					var isElement = false;
					foreach (var child in node.ChildNodes)
					{
						var isPreviousElement = isElement;
						var content = Stringify(child);
						isElement = child.NodeType == NodeType.Element;
						if (!String.IsNullOrEmpty(content) && isElement && isPreviousElement)
						{
							sb.Append(' ');
						}
						sb.Append(content);
					}
					return sb.ToString();
				}
				switch (node.NodeName.ToLowerInvariant())
				{
					case "br": return "\n";
				}
				goto default;
			default:
				return String.Empty;
		}
	}
