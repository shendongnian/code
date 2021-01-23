	[TestMethod]
	public void Strike_Format_Test()
	{
		//http://stackoverflow.com/questions/30517646/how-to-apply-strike-formatting-using-epplus
		var existingFile = new FileInfo(@"c:\temp\StrikeFormat.xlsx");
		using (var pck = new ExcelPackage(existingFile))
		{
			var wb = pck.Workbook;
			var ws = wb.Worksheets.First();
			var cell = ws.Cells["A1"];
			Console.WriteLine(cell.Style.Font.Strike);
		}
	}
