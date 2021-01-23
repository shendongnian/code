	[TestMethod]
	public void Copy_Styles_Test()
	{
		//http://stackoverflow.com/questions/31853046/epplus-copy-style-to-a-range
		//Throw in some data
		var datatable = new DataTable("tblData");
		datatable.Columns.AddRange(new[] {new DataColumn("Col1", typeof (int)), new DataColumn("Col2", typeof (int)), new DataColumn("Col3", typeof (int)) });
		for (var i = 0; i < 20; i++)
		{
			var row = datatable.NewRow();
			row[0] = i; row[1] = i * 10; row[2] = i * 100; 
			datatable.Rows.Add(row);
		}
		var existingFile = new FileInfo(@"c:\temp\test.xlsx");
		if (existingFile.Exists)
			existingFile.Delete();
		using (var pck = new ExcelPackage(existingFile))
		{
			const int RowCount = 5;
			
			//Show the data
			var xlsSheet = pck.Workbook.Worksheets.Add("Sheet1");
			xlsSheet.Cells.LoadFromDataTable(datatable, true);
			
			//Throw in some styles for testing
			xlsSheet.Row(18).Style.Fill.PatternType = ExcelFillStyle.Solid;
			xlsSheet.Row(18).Style.Fill.BackgroundColor.SetColor(Color.Aqua);
			xlsSheet.Cells["A18:C18"].Style.Fill.BackgroundColor.SetColor(Color.Red);
			//Insert new rows
			xlsSheet.InsertRow(18, RowCount);
			//Copy the cells and manually set the style IDs
			for (var i = 0; i < RowCount; i++)
			{
				var row = 18 + i;
				xlsSheet.Cells["23:23"].Copy(xlsSheet.Cells[String.Format("{0}:{0}", row)]);
				xlsSheet.Row(row).StyleID = xlsSheet.Row(23).StyleID;
			}
			//May not be needed but cant hurt
			xlsSheet.Cells["18:18"].Worksheet.Workbook.Styles.UpdateXml();
			
			//save it
			pck.Save();
		}
	}
