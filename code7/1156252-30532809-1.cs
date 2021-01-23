    var result = list1.Take(list2.Length)
		.Select((item, index) => 
		new 
		{
			Item = item, 
			Order = list2[index]
		})
		.OrderBy(x => x.Order)
		.Select(x => x.Item);
    var concatted = result.Concat(list1.Skip(list2.Length));
