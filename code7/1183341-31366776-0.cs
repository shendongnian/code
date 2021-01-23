	var things = new []
	{
		new { Id = 1, Name = "Fire", ParentId = (int?)null },
		new { Id = 2, Name = "Fire2", ParentId = (int?)1 },
		new { Id = 3, Name = "Fire3", ParentId = (int?)2 },
		new { Id = 4, Name = "Blast", ParentId = (int?)2 },
		new { Id = 5, Name = "Water", ParentId = (int?)null },
		new { Id = 6, Name = "Water2", ParentId = (int?)5 },
		new { Id = 7, Name = "Waterx", ParentId = (int?)5 }
	};
	
	var tree = things.ToLookup(x => x.ParentId, x => new { x.Id, x.Name });
