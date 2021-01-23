	var item = JObject.Parse(jsonText);
	var hasItems = item.Properties().Any(p => p.Name == "items");
	if(hasItems)
	{
		var items = item["items"].Select(t => t.ToObject<SomeClass>());
	}
	else
	{
		var sc = item.ToObject<SomeClass>();
	}
