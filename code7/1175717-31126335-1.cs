	[TestMethod]
	public void Big_Number_Format()
	{
		//http://stackoverflow.com/questions/31124487/write-to-excel-without-scientifc-notation-using-epplus
		var existingFile = new FileInfo(@"c:\temp\temp.xlsx");
		if (existingFile.Exists)
			existingFile.Delete();
		using (var package2 = new ExcelPackage(existingFile))
		{
			var ws = package2.Workbook.Worksheets.Add("Sheet1");
			ws.Cells[1, 1].Value = 20150602125320;
			ws.Cells[1, 2].Value = 20150602125320;
			ws.Cells[1, 1].Style.Numberformat.Format = "0";
			ws.Cells[1, 2].Style.Numberformat.Format = "0.00";
			package2.Save();
		}
	}
