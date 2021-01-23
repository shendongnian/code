	var result = myList.Aggregate(
		new { Sum = 0, List = new List<List<int>>() },
		(data, value) =>
		{
			int sum = data.Sum + value;
			if (data.List.Count > 0 && sum <= maxSum)
				data.List[data.List.Count - 1].Add(value);
			else
				data.List.Add(new List<int> { (sum = value) });
			return new { Sum = sum, List = data.List };
		},
		data => data.List)
		.ToList();
