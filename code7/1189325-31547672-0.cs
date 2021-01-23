    List<PriceDetail> list = new List<PriceDetail>
	{
		new PriceDetail {Id = 1, Age = 56, Name = "abc", group = "P1"},
		new PriceDetail {Id = 1, Age = 56, Name = "abc", group = "P2"},
		new PriceDetail {Id = 2, Age = 56, Name = "abc", group = "P1"}
	};
	Dictionary<PriceDetailKey, StringBuilder> group = new Dictionary<PriceDetailKey, StringBuilder>();
	for (int i = 0; i < list.Count; ++i)
	{
		var key = new PriceDetailKey { Id = list[i].Id, Age = list[i].Age, Name = list[i].Name };				
		if (group.ContainsKey(key))
		{
			group[key].Append(",");
			group[key].Append(list[i].group);
		}
		else
		{
			group[key] = new StringBuilder();
			group[key].Append(list[i].group);
		}
	}
	List<PriceDetail> retList = new List<PriceDetail>();
	foreach (KeyValuePair<PriceDetailKey, StringBuilder> kvp in group)
	{
		retList.Add(new PriceDetail{Age = kvp.Key.Age, Id = kvp.Key.Id, Name = kvp.Key.Name, group = kvp.Value.ToString()});
	}
