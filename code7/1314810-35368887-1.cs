    Microsoft.Office.Interop.Excel.Workbook objBook;
    Microsoft.Office.Interop.Excel.Sheets objSheets;
    Microsoft.Office.Interop.Excel._Worksheet workSheet;
    
    objBook = (Workbook)Globals.ThisAddIn.Application.ActiveWorkbook;
    
    if (objBook == null)
        {
           objBook = objApp.Workbooks.Add();
        }
    
    // get the collection of sheets in the workbook
    
    objSheets = objBook.Worksheets;
    
    // get the first and only worksheet from the collection of worksheets
    
    workSheet = (Microsoft.Office.Interop.Excel.Worksheet)objBook.ActiveSheet;
    
    workSheet.Cells[1, "A"] = "value1A";
