	public static List<List<Team>> GenerateGroups(List<Team> teams, int amount)
	{
		return teams.OrderBy(item => Guid.NewGuid())
				.Select((item, index) => new { Item = item, GroupIndex = index % amount })
				.GroupBy(item => item.GroupIndex, 
                         (key, group) => group.Select(groupItem => groupItem.Item).ToList())
                .ToList();
	}
