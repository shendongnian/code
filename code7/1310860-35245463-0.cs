    Microsoft.Office.Interop.Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();
    
    xlApp.Visible = true;
    
    Workbook wb = xlApp.Workbooks.Add(XlWBATemplate.xlWBATWorksheet);
    Worksheet ws = wb.Worksheets[1];
    
    xlApp.ActiveWindow.DisplayGridlines = false;
