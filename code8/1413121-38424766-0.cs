    public Worksheet openExcel()
    {
        var excelObj = new Microsoft.Office.Interop.Excel.Application();   
        string fileName = @"C:\Users\" + userName + @"\Documents\Visual Studio 2015\Projects\ProgramForMom\ProgramForMom\bin\Debug\Excel Files\" + frm2.year.Text + " Expenses";
        Workbook wb = excelObj.Workbooks.Open(fileName, 0, false, 5, "", "", false, XlPlatform.xlWindows, "", true, false, 0, true, false, false);    
        wb.Activate(); 
        Microsoft.Office.Interop.Excel.Worksheet ws = wb.Worksheets[frm2.month.Text];
        ws.Activate(); 
        return ws; // return the activated Worksheet
    }
