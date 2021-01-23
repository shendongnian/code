    public FileResult ExportData()
    {
        ExcelPackage package = new ExcelPackage();
        var ws = package.Workbook.Worksheets.Add("My Sheet");       
        ...
        ws.Cells[1,1].LoadFromDataTable(table, true, TableStyles.Light1);
        return new EpplusResult(package){FileDownloadName = "SomeFile.xlsx"};
    }
