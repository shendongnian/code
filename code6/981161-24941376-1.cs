	dynamic data = JsonConvert.DeserializeObject<dynamic>(jsonString);
    var list = new List<Item>();
	foreach (var itemDynamic in data)
	{
		list.Add(JsonConvert.DeserializeObject<Item>(((JProperty)itemDynamic).Value.ToString()));
	}
