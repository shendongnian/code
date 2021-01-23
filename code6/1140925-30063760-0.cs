	[TestMethod]
	public void Quartile_Range_Test()
	{
		//Throw in some data
		var dtMain = new DataTable("tblData");
		dtMain.Columns.Add(new DataColumn("Col1", typeof(int)));
		for (var i = 0; i < 20; i++)
		{
			var row = dtMain.NewRow();
			row["Col1"] = i * 100;
			dtMain.Rows.Add(row);
		}
		//Clear the file
		var newFile = new FileInfo(@"C:\Temp\Temp.xlsx");
		if (newFile.Exists)
			newFile.Delete();
		using (var package = new ExcelPackage(newFile))
		{
			var currentWorksheet = package.Workbook.Worksheets.Add("Test");
			currentWorksheet.Cells["C1"].LoadFromDataTable(dtMain, false);
			currentWorksheet.Cells[2, 4].Formula = "QUARTILE(C:C,1)";
			package.Save();
		}
	}
