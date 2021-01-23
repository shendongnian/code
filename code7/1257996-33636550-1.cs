     Microsoft.Office.Interop.Excel.Application excelApp = new 
     Microsoft.Office.Interop.Excel.Application();
     string myPath = txtPath.Text.ToString();
     
     excelApp.Workbooks.Open(myPath, 0, false, 5, "", "", false,  
     Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "",
                true, false, 0, true, false, false);
     excelApp.Cells[8, 3] = txtSum1.Text.ToString();
     excelApp.Cells[8, 4] = txtId1.Text.ToString();
    excelApp.ActiveWorkbook.Save();
    excelApp.Workbooks.Close();
    excelApp.Quit();
