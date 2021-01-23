	var listDictionaries = List2
		.Select(l => new Dictionary<string, object>()
		{
			new { "Prop1", l.Prop1 },
			new { "Prop2", l.Prop2 },
			new { "Prop3", l.Prop3 },
		}).ToArray();
	listDictionaries[ii][List1[i].field];
