	static void PopulateC(TreeView treeView, IEnumerable<Hierarchymain> source)
	{
		var itemsByParentId = source.ToLookup(item => item.ParentID);
        var parentNodesStack = new Stack<TreeNodeCollection>();
		var childEnumeratorStack = new Stack<IEnumerator<Hierarchymain>>();
		var parentNodes = treeView.Nodes;
		var childEnumerator = itemsByParentId[0].GetEnumerator();
		try {
			while (true)
			{
				while (childEnumerator.MoveNext())
				{
					var item = childEnumerator.Current;
					var node = parentNodes.Add(item.Label);
					parentNodesStack.Push(parentNodes);
					childEnumeratorStack.Push(childEnumerator);
					parentNodes = node.Nodes;
					childEnumerator = itemsByParentId[item.ID].GetEnumerator();
				}
				if (childEnumeratorStack.Count == 0) break;
				childEnumerator.Dispose();
				childEnumerator = childEnumeratorStack.Pop();
				parentNodes = parentNodesStack.Pop();
			}
		}
		finally
		{
			childEnumerator.Dispose();
			while (childEnumeratorStack.Count != 0) childEnumeratorStack.Pop().Dispose();
		}
	}
