    var table3Join =
		Table2
		.GroupJoin(
			Table3,
			ttwo => ttwo.Id,
			tthree => tthree.Table2Id,
			(ttwo, tthree) => new { ttwo = ttwo , tthree = tthree }
		);
			
	var sqlQuery = 
		Table1
		.GroupJoin(
			table3Join, 
				tone => tOne.Id,
				twwo => twwo.ttwo.Table1Id,
				(tone, ttwo) => new { tone = tone, ttwo = ttwo }
		).ToList();
	var tableResults = sqlQuery.Select(r => new TableResult1
	{
		Key = r.tone.Id,
		ListTableResult2 = r.ttwo.Select(ttwo => new TableResult2
		{
			Key = ttwo.ttwo.Id,
			ListTableResult3 = ttwo.tthree.Select(tthree => new TableResult3
			{
				Key = tthree.Id
			}).ToList()
		}).ToList()
	});
