	public static List<List<Team>> GenerateGroups(List<Team> teams, int amount)
	{
		Random random = new Random();
		return teams.OrderBy(item => random.NextDouble())
				.Select((item, index) => new { Item = item, GroupIndex = index % amount })
				.GroupBy(item => item.GroupIndex,
						 (key, group) => group.Select(groupItem => groupItem.Item).ToList())
				.ToList();
	}
