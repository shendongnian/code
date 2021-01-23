	public void Print(List<school> nodes, int? parentId, string prefix)
	{
		var nodesToPrint = nodes.Where(x => x.ParentID == parentId);
		foreach (var item in nodesToPrint)
		{
			Console.WriteLine(prefix + item.Description);
			Print(nodes, item.id, prefix + "-");
		}
	}
