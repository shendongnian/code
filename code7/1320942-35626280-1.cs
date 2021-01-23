    [TestMethod]
    public void TestExcelNumberFormatOnWholeSheet()
    {
        Excel.Application excel = new Excel.Application();
        excel.Visible = true;
        Excel.Workbook workbook1 = excel.Workbooks.Add();
        Excel.Worksheet sheet = workbook1.Sheets.Add();
        var lastCol = sheet.Range["a1"].End[Excel.XlDirection.xlToRight].Column;
        var lastRow = sheet.Cells[65536, lastCol].End[Excel.XlDirection.xlDown].Row;
        sheet.Range["a1", sheet.Cells[lastRow, lastCol]].NumberFormat = "%0,00";
    }
