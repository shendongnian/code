	[TestMethod]
	public void Big_Row_Count_Test()
	{
		var existingFile = new FileInfo(@"c:\temp\temp.xlsx");
		if (existingFile.Exists)
			existingFile.Delete();
		const int maxExcelRows = 1048576;
		using (var package = new ExcelPackage(existingFile))
		{
			//Assume a data row count
			var rowCount = 2000000;
			//Determine number of sheets
			var sheetCount = (int)Math.Ceiling((double)rowCount/ maxExcelRows);
			
			for (var i = 0; i < sheetCount; i++)
			{
				var ws = package.Workbook.Worksheets.Add(String.Format("Sheet{0}", i));
				var sheetRowLimit = Math.Min((i + 1)*maxExcelRows, rowCount);
				//Remember +1 for 1-based excel index
				for (var j = i * maxExcelRows + 1; j <= sheetRowLimit; j++)
				{
					var cell1 = ws.Cells[j - (i*maxExcelRows), 1];
					cell1.Value = j;
				}
			}
			package.Save();
		}
	}
