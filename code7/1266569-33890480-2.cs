	public Task<IEnumerable<BargeGroup>> GroupAsync(IEnumerable<Barge> ungroupedBarges)
	{
		// Do the grouping
		
		var riverTasks = riverBarges.Select(barges => 
											Task.Run(ResolveRiver(barges, ref groupNumber)));
											
		var result = await Task.WhenAll(riverTasks);
		bargeGroups.AddRange(result.Result.SelectMany(x => x));
		return bargeGroups;
	}
	
