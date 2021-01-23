    using Microsoft.Office.Interop.Excel;
    
    public void RangeWithCommas() {
        var excel = new Application();
        var wb = excel.Workbooks.Add(xlWBATemplate.xlWBATWorksheet);
        var ws = (Worksheet)wb.Worksheets[1];
        var rangestring = String.Join((string)excel.International[XlApplicationInternational.xlListSeparator], new [] {"A1","A2"});
        var range = ws.Range[rangestring];
        Console.WriteLine(range.Address[false,false]);
        ws.Delete();
        wb.Close(false);
        excel.Quit();
    }
