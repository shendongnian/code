	[TestMethod]
	public void Table_Export_Test()
	{
		//http://stackoverflow.com/questions/31042901/export-datatable-to-excel-using-epplus-with-additional-data
		//Throw in some data
		var dtdata = new DataTable("tblData");
		dtdata.Columns.Add(new DataColumn("Order no.", typeof (string)));
		dtdata.Columns.Add(new DataColumn("Product name", typeof (int)));
		dtdata.Columns.Add(new DataColumn("Name", typeof (int)));
		for (var i = 0; i < 20; i++)
		{
			var row = dtdata.NewRow();
			row[0] = i;
			row[1] = i*10;
			row[2] = i*100;
			dtdata.Rows.Add(row);
		}
		var existingFile = new FileInfo(@"c:\temp\temp.xlsx");
		if (existingFile.Exists)
			existingFile.Delete();
		using (var package = new ExcelPackage(existingFile))
		{
			var ws = package.Workbook.Worksheets.Add("Sheet1");
			ws.Cells["A1"].Value = "Product Statistics";
			ws.Cells[1, 1, 1, 6].Merge = true;
			ws.Cells[3, 3].Value = "Total";
			ws.Cells[3, 4].Value = "200";
			ws.Cells[4, 3].Value = "Sold out";
			ws.Cells[4, 4].Value = "50";
			ws.Cells[1, 1, 1, 6].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
			ws.Cells[3, 3, 6, 3].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
			ws.Cells[3, 4, 6, 4].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
			ws.Cells[6, 1].LoadFromDataTable(dtdata, true);
			ws.Column(1).Width = 13;
			ws.Column(2).Width = 13;
			ws.Column(3).Width = 13;
			ws.Column(4).Width = 13;
			package.Save();
		}
	}
