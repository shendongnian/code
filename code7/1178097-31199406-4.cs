    private static void Traverse(Node node)
    {
		node.Checked = true; 
        _nodes.Where(x => x.ParentId == node.Id).ToList().ForEach(Traverse);
	}
		
	public static void Check(params int[] values)
	{
		values.Select(item => _nodes.Single(x => x.Id == item)).ToList().ForEach(Traverse);
	}
