     Microsoft.Office.Interop.Excel.Application excelApp = new 
     Microsoft.Office.Interop.Excel.Application();
     string myPath = txtPath.Text.ToString();
     Microsoft.Office.Interop.Excel.Workbook excelWorkbook =   
     excelApp.Workbooks.Open(myPath,0, false, 5, "", "", false,  
     Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "",
                true, false, 0, true, false, false);
                Microsoft.Office.Interop.Excel.Worksheet workSheet =   
    (Microsoft.Office.Interop.Excel.Worksheet)excelWorkbook.ActiveSheet;
 
           excelApp.Cells[8, 3] = txtSum1.Text.ToString();
        excelApp.Cells[8, 4] = txtId1.Text.ToString();
    excelApp.ActiveWorkbook.Save();
    excelApp.Workbooks.Close();
    excelApp.Quit();
