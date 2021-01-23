	foreach (var group in myList.GroupBy(m => m.MyStructId))
	{
		Console.WriteLine("Group = {0}", group.Key);
		foreach (var item in group)
		{
			Console.WriteLine("Item = {0}, {1}, {2}", item.MyStructId, item.Properties1, item.Properties2)
		}
	}
