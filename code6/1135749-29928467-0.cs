    //Get DataGridView into a DataTable:
    var bindingSource = (BindingSource)dataGridView.DataSource;
    var dataView = (DataView)bindingSource.List;
    var dataTable = dataView.Table;
    //Create a Spreadsheet
    using (ExcelPackage excelPackage = new ExcelPackage())
    {
        ExcelWorksheet ws = excelPackage.Workbook.Worksheets.Add("DataExport");
        ws.Cells[1,1].LoadFromDataTable(dataTable, PrintHeaders:true);
        //Write to an outputstream:
        excelPackage.SaveAs(outputStream);
        //or filesystem:
        excelPackage.SaveAs(new FileInfo(@"C:\Temp\Export.xlsx"));
    }
