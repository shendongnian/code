    Excel.Application excel;
    Excel.Workbook wb;
    try
    {
        excel = (Excel.Application)Marshal.GetActiveObject("Excel.Application");
        excel.Visible = true;
        wb = (Excel.Workbook)excel.ActiveWorkbook;
    }
    catch (Exception ex)
    {
        ErrorMessage = "Trouble Locating Open Excel Instance";
        return;
    }
    Excel.Worksheet sheet = wb.Worksheets["Sheet1"];
    foreach (Excel.ListObject lo in sheet.ListObjects)
    {
        Excel.Range srcRow = lo.DataBodyRange;
        Excel.ListRow oLastRow = wb.Worksheets["Sheet2"].ListObjects["table1"].ListRows.Add();
        srcRow.Copy();
        oLastRow.Range.PasteSpecial(Excel.XlPasteType.xlPasteValues);
    }
