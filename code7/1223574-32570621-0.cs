	[TestMethod]
	public void Amp_String_Test()
	{
		//http://stackoverflow.com/questions/32569450/epplus-loadfromdatatable-is-double-escaping-ampersands
		//Throw in some data
		var datatable = new DataTable("tblData");
		datatable.Columns.AddRange(new[] { new DataColumn("Col1", typeof(int)), new DataColumn("Col2", typeof(int)), new DataColumn("Col3", typeof(object)) });
		for (var i = 0; i < 10; i++)
		{
			var row = datatable.NewRow(); row[0] = i; row[1] = i * 10;
			//Alternate text
			row[2] = i%2 == 0 ? "AT&amp;T": "AT&T"; 
			datatable.Rows.Add(row);
		}
		//Create a test file
		var fi = new FileInfo(@"c:\temp\amptest.xlsx");
		if (fi.Exists)
			fi.Delete();
		using (var pck = new ExcelPackage(fi))
		{
			var worksheet = pck.Workbook.Worksheets.Add("Sheet1");
			worksheet.Cells.LoadFromDataTable(datatable, true);
			pck.Save();
		}
	}
