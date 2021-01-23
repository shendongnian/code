    using Excel = Microsoft.Office.Interop.Excel;
    [ExcelCommand]
    public static void IterateOverRows(string worksheetName, string startAddress, string endAddress) {
        var app = (Excel.Application)ExcelDnaUtil.Application;
        var ws = (Excel.Worksheet)app.ActiveWorkbook.Sheets[worksheetName];
        var rows = ((System.Collections.IEnumerable)ws.Range[$"{startAddress}:{endAddress}"].Rows)
            .Cast<Excel.Range>();
        foreach (var row in rows) {
            row.Cells[1, 1].Value = "aaaa";
        }
    }
