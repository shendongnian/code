	[TestMethod]
	public void Multi_Range_Test()
	{
		//Throw in some data
		var datatable = new DataTable("tblData");
		datatable.Columns.Add(new DataColumn("Col1", typeof(int)));
		datatable.Columns.Add(new DataColumn("Col2", typeof(int)));
		datatable.Columns.Add(new DataColumn("Col3", typeof(int)));
		for (var i = 0; i < 20; i++)
		{
			var row = datatable.NewRow();
			row[0] = i;
			row[1] = i * 10;
			row[2] = i * 100;
			datatable.Rows.Add(row);
		}
		var existingFile2 = new FileInfo(@"c:\temp\temp.xlsx");
		if (existingFile2.Exists)
			existingFile2.Delete();
		using (var package = new ExcelPackage(existingFile2))
		{
			//Add the data
			var sheet = package.Workbook.Worksheets.Add("Sheet1");
			sheet.Cells.LoadFromDataTable(datatable, true);
			//Set autofilter
			var range = sheet.Cells["7:9,12:12,14:14"];
			foreach (var rangeBase in range)
			{
				Console.WriteLine("{{{0} : {1}}}", rangeBase.Address, rangeBase.Value);
			}
			//Save the file
			package.Save();
		}
	}
