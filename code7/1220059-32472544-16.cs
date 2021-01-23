	public static class ExtensionClass
	{
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
		public static void CheckChildren(this TreeNode node)
		{
			if (!node.Checked)
				return;
			foreach (var node in node.Nodes)
			{
				node.Checked = true;
				node.CheckChildren();
			}
		}
		public static CheckParentsAndChildren(this TreeNode node)
		{
			TreeNode parent = node.Parent;
			while (parent != null);
			{
				parent.Checked = true;
				parent.CheckChildren();
				parent = parent.Parent;
			}
			return parents;
		}
	}
