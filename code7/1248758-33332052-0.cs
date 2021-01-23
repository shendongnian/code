	// assuming you'll already have the subjects of the emails
	var subjects = new List<string>
	{
		"ABC / Vesse / 11371503 /C report",
		"Value/BEY/11371503/A report"
	};
	var listOfItems = new List<Tuple<string, string, int, string>>();
	subjects.ForEach(s =>
	{
		var splits = s.Split(new[] {'/'}, StringSplitOptions.RemoveEmptyEntries).Select(x => x.Trim()).ToArray();
		// Do proper error checking before the int.Parse and make sure every array has 4 elements
		listOfItems.Add(
			new Tuple<string, string, int, string>(splits[0], 
													splits[1], 
													int.Parse(splits[2]), 
													splits[3]));
	});
	var newList = listOfItems
		.OrderBy(x => x.Item3) // the number
		.ThenBy(x => x.Item4) // {x} report
		.ToList();
