    List<string> list = new List<string>();
    list.Add("0-0-44,25");
    list.Add("1-0-41");
    list.Add("0-1-28");
    list.Add("1-1-33");
    list.Add("0-2-37,33");
    list.Add("1-2-44,33");
	List<Item> items = new List<Item>();
	foreach (var item in list)
	{
        // split all of your strings and put it into the item class and then add it to the list
		string[] parts = item.Split('-');
		items.Add(new Item()
		{
			first = parts[0],
			second = parts[1],
			third = parts[2]
		});
	}
    // now you're able to sort it (by the second property)
	var result = items.OrderBy(x => x.second);
    List<string> resultList = new List<string>();
    // and now put it back together
	foreach (var item in result)
	{
		resultList.Add(string.Format("{0}-{1}-{2}", item.first, item.second, item.third));
	}
