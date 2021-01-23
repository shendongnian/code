    public List<SourceFile>[] Distribute(List<SourceFile> files, int partitionCount)
    {
        List<SourceFile> sourceFilesSorted =
			files
				.OrderByDescending(sf => sf.Size)
				.ToList();
				
        List<SourceFile>[] groups =
			Enumerable
				.Range(0, partitionCount)
				.Select(l => new List<SourceFile>())
				.ToArray();
		foreach (var f in files)
		{
			groups
				.Select(grp => new { grp, size = grp.Sum(x => x.Size) })
				.OrderBy(grp => grp.size)
				.First()
				.grp
				.Add(f);
		}
		
		return groups;
    }
