	var filesSetsWithPossibleDupes = files.GroupBy(f => f.FileSize)
                                  		  .Where(grp => grp.Count() > 1);
	
	var masterDuplicateDict = new Dictionary<DupStats, IEnumerable<DupInfo>>();
	//A dictionary keyed by the basic duplicate stats
	//, and whose value is a collection of the possible duplicates
	
	foreach (var grp in filesSetsWithPossibleDupes)
	{
		var likelyDuplicates = grp.GroupBy(dup => dup.Checksum)
							      .Where(g => g.Count() > 1);
		//Same GroupBy logic, but applied to the checksum (instead of file size)
		foreach(var dupGrp in likelyDuplicates)
		{
            //Create the key for the dictionary (your code is likely different)
			var sample = dupGrp.First();
			var key = new DupStats() {FileSize = sample.FileSize, Checksum = sample.Checksum};
			masterDuplicateDict.Add(key, dupGrp);
		}
	}
