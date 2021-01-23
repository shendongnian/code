	public Task<IEnumerable<BargeGroup>> GroupAsync(IEnumerable<Barge> ungroupedBarges)
	{
		// Do the grouping
		
		var riverTasks = riverBarges.Select(barges => 
											Task.Run(ResolveRiver(barges, ref groupNumber)));
											
		await Task.WhenAll(riverTasks);
		bargeGroups.AddRange(riverTasks.Result.SelectMany(x => x));
		return bargeGroups;
	}
	
