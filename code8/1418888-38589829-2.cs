	public static List<List<int>> GenerateGroups(List<int> teams, int amount)
	{
		Random random = new Random();
		return teams.OrderBy(item => random.Next(teams.Count))
				.Select((item, index) => new { Item = item, GroupIndex = index % amount })
				.GroupBy(item => item.GroupIndex,
						 (key, group) => group.Select(groupItem => groupItem.Item).ToList())
				.ToList();
	}
