    public static class NodeRecursiveChecker
	{
		private static List<Node> _nodes;
		private static void Traverse(Node node)
		{
			node.Checked = true; 
            _nodes.Where(x => x.ParentId == node.Id).ToList().ForEach(Traverse);
		}
		
		public static void Check(this List<Node> nodes, params int[] values)
		{
			_nodes = nodes;
			values.Select(item => _nodes.Single(x => x.Id == item)).ToList().ForEach(Traverse);
		}
	}
