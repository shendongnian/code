	[TestMethod]
	public void Cells_To_Dictionary_Test()
	{
		//http://stackoverflow.com/questions/32066500/get-all-the-cell-values-from-excel-using-epplus
		//Throw in some data
		var datatable = new DataTable("tblData");
		datatable.Columns.AddRange(new[] { new DataColumn("Col1", typeof(int)), new DataColumn("Col2", typeof(int)), new DataColumn("Col3", typeof(object)) });
		for (var i = 0; i < 10; i++)
		{
			var row = datatable.NewRow();
			row[0] = i; 
			row[1] = i * 10;
			row[2] = Path.GetRandomFileName();
			datatable.Rows.Add(row);
		}
		//Create a test file
		var existingFile = new FileInfo(@"c:\temp\Grouped.xlsx");
		if (existingFile.Exists)
			existingFile.Delete();
		using (var pck = new ExcelPackage(existingFile))
		{
			var worksheet = pck.Workbook.Worksheets.Add("Sheet1");
			worksheet.Cells.LoadFromDataTable(datatable, true);
			pck.Save();
		}
		//Load a dictionary from a file
		using (var pck = new ExcelPackage(existingFile))
		{
			var worksheet = pck.Workbook.Worksheets["Sheet1"];
            //Cells only contains references to cells with actual data
			var cells = worksheet.Cells;
			var dictionary = cells
				.GroupBy(c => new {c.Start.Row, c.Start.Column})
				.ToDictionary(
					rcg => new KeyValuePair<int, int>(rcg.Key.Row, rcg.Key.Column),
					rcg => cells[rcg.Key.Row, rcg.Key.Column].Value);
			foreach (var kvp in dictionary)
				Console.WriteLine("{{ Row: {0}, Column: {1}, Value: \"{2}\" }}", kvp.Key.Key, kvp.Key.Value, kvp.Value);
		}
	}
