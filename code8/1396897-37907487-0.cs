	public void Detect_Tables_Test()
	{
		//http://stackoverflow.com/questions/37901408/interpreting-an-excel-file-in-c-sharp
		var fileInfo = new FileInfo(@"c:\temp\DetectTablesTest.xlsx");
		using (var pck = new ExcelPackage(fileInfo))
		{
			var workbook = pck.Workbook;
			var worksheet = workbook.Worksheets.First();
			var tables = worksheet.Tables;
			tables.ToList().ForEach(table =>
			{
				Console.WriteLine($"{{Name: {table.Name}, Address: {table.Address}, Columns: {table.Columns.Count}}}");
			});
		}
	}
