	[TestMethod]
	public void Grouped_Row_Test()
	{
		//http://stackoverflow.com/questions/30466257/selecting-grouped-max-and-min-in-a-epplus-worksheet-with-linq
		var existingFile = new FileInfo(@"c:\temp\Grouped.xlsx");
		using (var pck = new ExcelPackage(existingFile))
		{
			var _dataSheet = pck.Workbook.Worksheets.First();
			//Group cells by row
			var rowcellgroups = _dataSheet
				.Cells["A:H"]
				.GroupBy(c => c.Start.Row);
			//Now group rows the column A; Skip the first row since it has the header
			var groups = rowcellgroups
				.Skip(1)
				.GroupBy(rcg => rcg.First().Value);
			//Reproject the groups for the min/max values; Column E = 5
			var maxMinGrouped = groups
				.Select(g => new
				{
					Group = g.Key,
					MaxDailyIndex = g.Select(o => o.First(rc => rc.Start.Column == 5)).Max(rc => rc.Value),
					MinDailyIndex = g.Select(o => o.First(rc => rc.Start.Column == 5)).Min(rc => rc.Value)
				});
			maxMinGrouped
				.ToList()
				.ForEach(mmg => Console.WriteLine("{{Group: \"{0}\", Min={1}, Max={2}}}", mmg.Group, mmg.MinDailyIndex, mmg.MaxDailyIndex));
		}
	}
