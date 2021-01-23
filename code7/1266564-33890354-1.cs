	public async Task<IEnumerable<BargeGroup>> Group(IEnumerable<Barge> ungroupedBarges)
	{
		List<BargeGroup> bargeGroups = new List<BargeGroup>();
		Int32 groupNumber = 0;
		var riverBarges = from barge in ungroupedBarges
						  where barge != null && !String.IsNullOrEmpty(String.Intern(barge.River))
						  let river = String.Intern(barge.River)
						  orderby river, barge.MileMarker ascending
						  group barge by river into barges
						  select barges.AsEnumerable();
		
		foreach (IEnumerable<Barge> barges in riverBarges)
		{
			await Task.Run(() => ResolveRiver(barges, ref groupNumber)).ContinueWith(t=>
			{
				IEnumerable<BargeGroup> riverGroups = t.Result;
				bargeGroups.AddRange(riverGroups);
			});
		}
		
		return bargeGroups;
	}
