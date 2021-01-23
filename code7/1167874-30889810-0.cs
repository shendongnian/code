    public bool IsFilterExistInExcel(string excelpath)
        {
           	bool IsFilterExist=false;
		        Microsoft.Office.Interop.Excel.Application excelApp = null;
                Microsoft.Office.Interop.Excel.Workbooks workBooks = null;
                Microsoft.Office.Interop.Excel.Workbook workBook = null;
                Microsoft.Office.Interop.Excel.Worksheet workSheet;
                excelApp = new Microsoft.Office.Interop.Excel.Application();
                workBooks = excelApp.Workbooks;
                workBook = workBooks.Open(excelpath, 0, true, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
                workSheet = workBook.Worksheets.get_Item(1);
              
            	IsFilterExist = workSheet.AutoFilterMode;
            	return IsFilterExist;
	}
