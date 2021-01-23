     xlApp = new Microsoft.Office.Interop.Excel.Application();
     Microsoft.Office.Interop.Excel.Workbook excelWorkbook = xlApp.Workbooks.Open(fileName);
     Microsoft.Office.Interop.Excel._Worksheet sheet = excelWorkbook.Sheets[1];
     var LastRow = sheet.UsedRange.Rows.Count;
     LastRow = LastRow + sheet.UsedRange.Row - 1;
     for (int i = 1; i <= LastRow; i++)
     {
       if (application.WorksheetFunction.CountA(sheet.Rows[i]) == 0)
           (sheet.Rows[i] as Microsoft.Office.Interop.Excel.Range).Delete();
     }
