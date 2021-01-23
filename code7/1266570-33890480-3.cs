	public async Task FooAsync()
	{
		var barges = await GroupAsync(ungroupedBarges);
		ShowBargeGroups(barges);
	}
	
