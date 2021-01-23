	private static void Test0(ApplicationDbContext myDbContext)
	{
		var ggparent = myDbContext.GrandGrandParents
			.Include(ggp => ggp.GrandParents)
			.ThenInclude(gp => gp.Parents)
			.ThenInclude(p => p.Children)
			.FirstOrDefault(ggp => ggp.ID == 3);
		if (ggparent == null)
		{
			DebugPrint("GrandGrandParent not found");
			return;
		}
		DebugPrint("GrandGrandParent:");
		DebugPrint(ggparent);
		if (ggparent.GrandParents == null)
		{
			DebugPrint("GrandParents null");
			return;
		}
		foreach (var gparent in ggparent.GrandParents)
		{
			DebugPrint(gparent);
			if (gparent.Parents == null) continue;
			foreach (var parent in gparent.Parents)
			{
				DebugPrint(parent);
				if (parent.Children == null) continue;
				foreach (var child in parent.Children)
				{
					DebugPrint(child);
				}
			}
		}
		int changeCount = myDbContext.SaveChanges();
		DebugPrint(string.Format("ChangeCount={0}", changeCount));
	}
