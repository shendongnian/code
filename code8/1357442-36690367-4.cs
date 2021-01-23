	public static void MethodD()
	{
		var originalList = new List<int>(Enumerable.Range(1, 1000));
		var list = new List<int>(originalList.Count);
		foreach (var item in originalList)
		{
			if (item <= 500)
				list.Add(item);
		}
		list.Capacity = list.Count;
	}
