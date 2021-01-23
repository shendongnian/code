	[TestMethod]
	public void Conditional_Format_Test()
	{
		//http://stackoverflow.com/questions/31296039/conditional-formatting-using-epplus
		var existingFile = new FileInfo(@"c:\temp\temp.xlsx");
		if (existingFile.Exists)
			existingFile.Delete();
		//Throw in some data
		var datatable = new DataTable("tblData");
		datatable.Columns.Add(new DataColumn("Col1", typeof(int)));
		datatable.Columns.Add(new DataColumn("Col2", typeof(int)));
		datatable.Columns.Add(new DataColumn("Col3", typeof(int)));
		for (var i = 0; i < 20; i++)
		{
			var row = datatable.NewRow();
			row["Col1"] = i;
			row["Col2"] = i * 10;
			row["Col3"] = i * 100;
			datatable.Rows.Add(row);
		}
		using (var pack = new ExcelPackage(existingFile))
		{
			var ws = pack.Workbook.Worksheets.Add("Content");
			ws.Cells["E1"].LoadFromDataTable(datatable, true);
			//Override E1
			ws.Cells["E1"].Value = "3";
			string _statement = "$E1=\"3\"";
			var _cond = ws.ConditionalFormatting.AddExpression(new ExcelAddress(ws.Dimension.Address));
			_cond.Style.Fill.PatternType = ExcelFillStyle.Solid;
			_cond.Style.Fill.BackgroundColor.Color = Color.LightCyan;
			_cond.Formula = _statement;
			pack.SaveAs(existingFile);
		}
	}
