    DataTable dataSource = new DataTable();
    dataSource.Columns.Add("Id");   
    dataSource.Columns.Add("Title");
    dataSource.Rows.Add("1", "Title1");
    using (var excel = new OfficeOpenXml.ExcelPackage())
    {
        var sheet = excel.Workbook.Worksheets.Add("Test");
        sheet.Cells["A1"].LoadFromDataTable(dataSource, true);
        sheet.Row(1).Height = 5;
        sheet.Row(2).Height = 5;
        sheet.Row(1).CustomHeight = false; // This will auto-size the header
        excel.SaveAs(new FileInfo("Path"));
    }
