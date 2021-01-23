	[TestMethod]
	public void Current_Cell_Test()
	{
		//http://stackoverflow.com/questions/32516676/trying-to-read-excel-file-with-epplus-and-getting-system-nullexception-error
		//Throw in some data
		var datatable = new DataTable("tblData");
		datatable.Columns.AddRange(new[] { new DataColumn("Col1", typeof (int)), new DataColumn("Col2", typeof (int)),new DataColumn("Col3", typeof (object)) });
		for (var i = 0; i < 10; i++)
		{
			var row = datatable.NewRow(); row[0] = i; row[1] = i * 10; row[2] = Path.GetRandomFileName(); datatable.Rows.Add(row);
		}
		//Create a test file
		var fi = new FileInfo(@"c:\temp\test1.xlsx");
		if (fi.Exists)
			fi.Delete();
		using (var pck = new ExcelPackage(fi))
		{
			var worksheet = pck.Workbook.Worksheets.Add("Sheet1");
			worksheet.Cells.LoadFromDataTable(datatable, true);
			pck.Save();
		}
		var dt = new DataTable();
		using (ExcelPackage xlPackage = new ExcelPackage(fi))
		{
			//Get the worksheet in the workbook 
			ExcelWorksheet worksheet = xlPackage.Workbook.Worksheets.First();
			//Obtain the worksheet size 
			ExcelCellAddress startCell = worksheet.Dimension.Start;
			ExcelCellAddress endCell = worksheet.Dimension.End;
			//Create the data column 
			for (int col = startCell.Column; col <= endCell.Column; col++)
			{
				dt.Columns.Add(col.ToString());
			}
			for (int row = startCell.Row; row <= endCell.Row; row++)
			{
				DataRow dr = dt.NewRow(); //Create a row
				int i = 0;
				for (int col = startCell.Column; col <= endCell.Column; col++)
				{
					dr[i++] = worksheet.Cells[row, col].Value.ToString();
				}
				dt.Rows.Add(dr);
			}
		}
		Console.Write("{{dt Rows: {0} Columns: {1}}}", dt.Rows.Count, dt.Columns.Count);
	}
