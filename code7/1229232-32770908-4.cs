	static void Populate(TreeView treeView, List<Hierarchymain> source)
	{
		var itemById = source.ToDictionary(item => item.ID);
		var nodeById = new Dictionary<int, TreeNode>();
		var addStack = new Stack<Hierarchymain>();
		foreach (var nextItem in source)
		{
			// Collect the info about the nodes that need to be created and where
			TreeNodeCollection parentNodes;
			for (var item = nextItem; ; item = itemById[item.ParentID])
			{
				TreeNode node;
				if (nodeById.TryGetValue(item.ID, out node))
				{
					// Already processed
					parentNodes = node.Nodes;
					break;
				}
				addStack.Push(item);
				if (item.ParentID == 0)
				{
					// Root item
					parentNodes = treeView.Nodes;
					break;
				}
			}
			// Create node for each collected item in reverse order
			while (addStack.Count > 0)
			{
				var item = addStack.Pop();
				var node = parentNodes.Add(item.Label);
				nodeById.Add(item.ID, node);
				parentNodes = node.Nodes;
			}
		}
	}
