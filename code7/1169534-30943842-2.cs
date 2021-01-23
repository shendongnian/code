	var grouped = GetItems()
		.OrderBy(x => x.OrderNo)
		.MakeSets((prev, next) => next.OrderNo == prev.OrderNo + 1)
		.Select(x => new FactoryOrder(
			String.Join(" ", x.Select(y => y.Text).ToArray()),
			x.First().OrderNo))
		.ToList();
	foreach (var item in grouped)
	{
		Console.WriteLine(item.Text + "\t" + item.OrderNo);
	}
