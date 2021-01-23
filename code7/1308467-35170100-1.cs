	var colorPallete = new string[]
	{
		"color1", "color2", "color3", "color4", "color5",
	};
	
	var previousList = new []
	{
		new { ID = 1, Name = "abc", Class = "Senior", },
		new { ID = 2, Name = "xyz", Class = "Medium", },
		new { ID = 3, Name = "pqr", Class = "junior", },
		new { ID = 1, Name = "mno", Class = "junior", },
	};
	
	var newList =
		previousList
			.Select(x => new
			{
				x.ID,
				x.Name,
				x.Class,
				Color = colorPallete.ElementAtOrDefault(x.ID - 1),
			})
			.ToList();
