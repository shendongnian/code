	var _excelApp = new Microsoft.Office.Interop.Excel.Application();
	_excelApp.Visible = true;
	var fileName = "D:\\data.xlsx";
	var workbooks = _excelApp.Workbooks;
	var workbook = workbooks.Open(fileName, Type.Missing);
	var worksheet = (Worksheet)workbook.Worksheets[1];
	var excelRange = worksheet.UsedRange;
	Object[,] valueArray = (object[,])excelRange.get_Value(XlRangeValueDataType.xlRangeValueDefault);
	int num = worksheet.UsedRange.Rows.Count;
	Marshal.FinalReleaseComObject(excelRange);
	Marshal.FinalReleaseComObject(worksheet);
	workbook.Close(false, Type.Missing);
	Marshal.FinalReleaseComObject(workbook);
	Marshal.FinalReleaseComObject(workbooks);
	_excelApp.Quit();
	
	Marshal.FinalReleaseComObject(_excelApp);
	
	for (int row = 1; row <= num; ++row)
	{
		data1.Add(Convert.ToDouble(valueArray[row, 1]));
		data2.Add(Convert.ToDouble(valueArray[row, 2]));
	}
