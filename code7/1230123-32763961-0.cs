	[TestMethod]
	public void Row_Col_Grouping_Test()
	{
		//http://stackoverflow.com/questions/32760210/how-to-group-rows-columns-in-epplus
		//Throw in some data
		var datatable = new DataTable("tblData");
		datatable.Columns.AddRange(new[]
		{
			new DataColumn("Header", typeof (string)), new DataColumn("Col1", typeof (int)), new DataColumn("Col2", typeof (int)), new DataColumn("Col3", typeof (object))
		});
		for (var i = 0; i < 10; i++)
		{
			var row = datatable.NewRow();
			row[0] = String.Format("Header {0}", i); row[1] = i; row[2] = i*10; row[3] = Path.GetRandomFileName(); datatable.Rows.Add(row);
		}
		//Create a test file
		var fi = new FileInfo(@"c:\temp\grouping.xlsx");
		if (fi.Exists)
			fi.Delete();
		using (var pck = new ExcelPackage(fi))
		{
			var worksheet = pck.Workbook.Worksheets.Add("Sheet1");
			worksheet.Cells.LoadFromDataTable(datatable, true);
			worksheet.Cells["B12"].Formula = "SUM(B2:B11)";
			worksheet.Cells["C12"].Formula = "SUM(C2:C11)";
			
			//Row Group 1
			for (var i = 2; i <= 6; i++)
			{
				worksheet.Row(i).OutlineLevel = 1;
				worksheet.Row(i).Collapsed = true;
			}
			//Row Group 2
			for (var i = 6; i <= 10; i++)
			{
				worksheet.Row(i).OutlineLevel = 2;
				worksheet.Row(i).Collapsed = true;
			}
			//Column Group
			for (var i = 2; i <= 4; i++)
			{
				worksheet.Column(i).OutlineLevel = 1;
				worksheet.Column(i).Collapsed = true;
			}
			pck.Save();
		}
	}
