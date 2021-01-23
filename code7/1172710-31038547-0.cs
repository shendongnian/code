	dbContext.Nodes
         .Where(c => c.NodeName.Contains(query))
		 .Select(c=>GetParentOrSelf(c,query))
         .OrderBy(n => n.NodeName)
         .ToPagedListAsync(page ?? 1, pageSize);	
	private Node GetParentOrSelf(Node n)
	{
		if (n.Parent==null)
			return n;
		else
		{
			if (n.Parent.NodeName.Contains(query))
				return GetParentOrSelf(n.Parent);
			else
				return n;
		}
	}
