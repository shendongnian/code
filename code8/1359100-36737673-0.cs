		EndResults =
		(
			from tr in TempResults
			join d in Disagio on tr.Column13 equals d.Column1
			select new MyList<string, string, string, string>()
			{
			        Column0 = tr.Column0,
			        Column1 = d.Column2,
			        Column2 = tr.Column1,
			        Column3 = tr.Column12
			}
		)
			.DistinctBy(x => x.Column0)
		    .ToList();
