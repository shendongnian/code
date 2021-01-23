	private void PrintQuery(TreeView treeView)
	{
		string s = string.Empty;
		TreeNodeCollection nodes = treeView.Nodes;
		s = nodes.Cast<TreeNode>().Aggregate(s, (current, n) => current + (n.ToString() + Environment.NewLine)).Trim();
		//remove unwanted brackets
		s = s.Remove(s.Length - 1).Substring(1).Trim();
		textBox1.Text = s;
	}
