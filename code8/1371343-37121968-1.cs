    [ExcelCommand]
    public static void IterateOverRows2([ExcelArgument(AllowReference = true)] object range) {
        var app = (Excel.Application)ExcelDnaUtil.Application;
        var xlRng = app.Range[XlCall.Excel(XlCall.xlfReftext, (ExcelReference)range, true)];
        var rows = ((System.Collections.IEnumerable)xlRng.Rows).Cast<Excel.Range>();
        foreach (var row in rows) {
            row.Cells[1, 1].Value = "aaaa";
        }
    }
