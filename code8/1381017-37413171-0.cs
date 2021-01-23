    public void InsertChartIntoChartlist()
	{
		try
		{
			// Create an instance of PowerPoint.
			var powerpointApplication = new Microsoft.Office.Interop.PowerPoint.Application();
			// Create an instance Excel.
			var excelApplication = new Microsoft.Office.Interop.Excel.Application();
			// Open the Excel workbook containing the worksheet with the chart data.
			var excelWorkBook = excelApplication.Workbooks.Open(@"C:\Book1.xlsx");
			// Get the worksheet that contains the chart.
			var targetSheet = excelWorkBook.Worksheets[2];
			// Get the ChartObjects collection for the sheet.
			var chartObjects = targetSheet.ChartObjects(Type.Missing);
			foreach (Microsoft.Office.Interop.Excel.ChartObject item in chartObjects)
			{
				item.Copy();
			}
		}
		catch (Exception ex)
		{
			Console.WriteLine(ex.Message);
		}
	}
