	var groupId = 0;
	var previous = Int32.MinValue;
	var grouped = GetItems()
		.OrderBy(x => x.OrderNo)
		.Select(x =>
		{
			var @group = x.OrderNo != previous + 1 ? (groupId = x.OrderNo) : groupId;
			previous = x.OrderNo;
			return new
					{
						GroupId = group,
						Item = x
					};
		})
		.GroupBy(x => x.GroupId)
		.Select(x => new FactoryOrder(
           String.Join(" ", x.Select(y => y.Item.Text).ToArray()), 
           x.Key))
		.ToArray();
	foreach (var item in grouped)
	{
		Console.WriteLine(item.Text + "\t" + item.OrderNo);
	}
