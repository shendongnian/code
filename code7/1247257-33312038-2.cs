	//Throw in some data
	var datatable = new DataTable("tblData");
	datatable.Columns.AddRange(new[]
	{
		new DataColumn("Col1", typeof (int)), new DataColumn("Col2", typeof (int)), new DataColumn("Col3", typeof (object))
	});
	for (var i = 0; i < 10; i++)
	{
		var row = datatable.NewRow();
		row[0] = i; row[1] = i*10; row[2] = Path.GetRandomFileName();
		datatable.Rows.Add(row);
	}
	const string tablename = "PivotTableSource";
	using (var pck = new ExcelPackage())
	{
		var workbook = pck.Workbook;
		var source = workbook.Worksheets.Add("source");
		source.Cells.LoadFromDataTable(datatable, true);
		var datacells = source.Cells["A1:C11"];
		source.Tables.Add(datacells, tablename);
		var pivotsheet = workbook.Worksheets.Add("pivot");
		pivotsheet.PivotTables.Add(pivotsheet.Cells["A1"], datacells, "PivotTable1");
		using (var orginalzip = new ZipArchive(new MemoryStream(pck.GetAsByteArray()), ZipArchiveMode.Read))
		{
			var fi = new FileInfo(@"c:\temp\Pivot_From_Table.xlsx");
			if (fi.Exists)
				fi.Delete(); 
			
			var result = orginalzip.SetCacheSourceToTable(fi, tablename, 1);
			Console.Write("Cache source was updated: ");
			Console.Write(result);
		}
	}
