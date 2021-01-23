        // Example data
        var list = new[] { "a;b;c;d", null, "w;x;y;z;", "m;m;m;d", "", "one;two", "empty;empty;empty;" };
		
		List<string> unicsL = list
			.Where(x => !string.IsNullOrWhiteSpace(x) && x.Split(';').Length > 2)
			.Select(x => x.Split(';')[3])
			.Where(x => !string.IsNullOrWhiteSpace(x))
			.GroupBy(x => x)
			.Select(g => g.First())
			.ToList();
		
