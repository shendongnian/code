	string str = "<p>To view more types of cereal click <a href=\"http://www.cereal.com\">here cereal</a>.</p>";
	var cq = CQ.Create(str);
	foreach (IDomElement node in cq.Elements)
	{
		PerformActionOnTextNodeRecursively(node, domNode => domNode.NodeValue = domNode.NodeValue.Replace("cereal", "<span>cereal</span>"));
	}
	Console.WriteLine(cq.Render());
	private static void PerformActionOnTextNodeRecursively(IDomNode node, Action<IDomNode> action)
	{
		foreach (var childNode in node.ChildNodes)
		{
			if (childNode.NodeType == NodeType.TEXT_NODE)
			{
				action(childNode);
			}
			else
			{
				PerformActionOnTextNodeRecursively(childNode, action);
			}
		}
	}
