    DataTable dataSource = new DataTable();
    dataSource.Columns.Add("Id");    // default type is string 
    dataSource.Columns.Add("Title");  
    // add other columns
    dataSource.Rows.Add("1", "Title1");
    // add other rows
    using (var excel = new OfficeOpenXml.ExcelPackage())
    {
        var sheet = excel.Workbook.Worksheets.Add("Test");
        sheet.Cells["A1"].LoadFromDataTable(dataSource, true);
        excel.SaveAs(new FileInfo(@"C:\Temp\Test.xlsx"));
    }
