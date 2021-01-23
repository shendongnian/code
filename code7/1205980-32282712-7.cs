    var filepath = @"C:\temp\test\book2.xlsx";
    var xlApp = new Microsoft.Office.Interop.Excel.Application();
    // Optional, but recommended if the user shouldn't see Excel.
    xlApp.Visible = false;
    xlApp.ScreenUpdating = false;
    // AddToMru parameter is optional, but recommended in automation scenarios.
    var workbook = xlApp.Workbooks.Open(filepath, AddToMru: false);
    var cell = xlApp.Range["C1:C1"];
    cell.Value2 = "=CELL(\"format\",A1)";
    //Fill Down
    cell.AutoFill(xlApp.Range["C1:C6"], Microsoft.Office.Interop.Excel.XlAutoFillType.xlFillDefault);
    //Fill Across
    cell = xlApp.Range["C1:C6"];
    cell.AutoFill(xlApp.Range["C1:D6"], Microsoft.Office.Interop.Excel.XlAutoFillType.xlFillDefault);
    
    object[,] rangeFormats = xlApp.get_Range("C1:D6").Value2;
