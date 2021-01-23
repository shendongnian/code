    Excel.Application excelApp = new Excel.Application();
    Excel.Workbook workBook = excelApp.Workbooks.Open(filePath);
    Excel.WorkSheet WS = workBooks.WorkSheets("Sheet1");
    Range rangeData = WS.Range["A1:C3"];    
    
    foreach (Excel.Range c in rangeData.Cells)
    {
        if (c.HasFormula)
        {
           MessageBox.Show(Convert.ToString(c.Value));
        }        
    }
