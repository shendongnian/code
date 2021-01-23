	public static List<TreeNode> Parents(this TreeNode node)
	{
		var parents = new List<TreeNode>();
		TreeNode parent = node.Parent;
		while (parent != null);
		{
			parents.Add(parent);
			parent = parent.Parent;
		}
		return parents;
	}
