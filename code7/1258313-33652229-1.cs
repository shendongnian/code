	[TestMethod]
	public void Multi_Sheet_Export_Test()
	{
		//Throw in some data
		var datatable = new DataTable("tblData");
		datatable.Columns.AddRange(new[]
		{
			new DataColumn("Col1", typeof (int)), new DataColumn("Col2", typeof (int)), new DataColumn("Col3", typeof (object))
		});
		for (var i = 0; i < 10; i++)
		{
			var row = datatable.NewRow();
			row[0] = i;
			row[1] = i*10;
			row[2] = i%2 == 0 ? "LocationX" : "LocationY";
			datatable.Rows.Add(row);
		}
		//Create a test file
		var fi = new FileInfo(@"c:\temp\Multi_Sheet_Export.xlsx");
		if (fi.Exists)
			fi.Delete();
		using (var pck = new ExcelPackage(fi))
		{
			var workbook = pck.Workbook;
			var colnames = new List<string[]>
			{
				datatable
					.Columns
					.Cast<DataColumn>()
					.Select(col => col.ColumnName)
					.ToArray()
			};
				
			var rowgroups = datatable
				.Rows
				.Cast<DataRow>()
				.GroupBy(row => row[2])
				.ToList();
			rowgroups.ForEach(rowgroup =>
			{
				var worksheet = workbook.Worksheets.Add(rowgroup.Key.ToString());
				worksheet.Cells[1, 1].LoadFromArrays(colnames);
				worksheet.Cells[2, 1].LoadFromArrays(rowgroup.Select(row => row.ItemArray));
			});
			pck.Save();
		}
	}
