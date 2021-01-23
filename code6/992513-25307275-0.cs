     var wb = new XLWorkbook();
            var dataTable = GetTable("Information");
            // Add a DataTable as a worksheet
            wb.Worksheets.Add(dataTable);
            wb.SaveAs("AddingDataTableAsWorksheet.xlsx");
