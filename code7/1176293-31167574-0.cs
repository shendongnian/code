    var data = GetDataFromSql();
    
    using (var excelPackage = new ExcelPackage(new FileInfo(@"C:\Proj\Sample\Book1.xlsx")))
    {
        var worksheet = excelPackage.Workbook.Worksheets.First();
    
        // Get locations of column names inside excel:
        var headersLocation = new Dictionary<string, Tuple<int, int>>();
        foreach (DataColumn col in data.Columns)
        {
            var cell = worksheet.Cells.First(x => x.Text.Equals(col.ColumnName));
            headersLocation.Add(col.ColumnName, new Tuple<int, int>(cell.Start.Row, cell.Start.Column));
        }
                    
        for (var i = 0; i < data.Rows.Count; i++)
        {
            foreach (DataColumn col in data.Columns)
            {
                // update the value
                worksheet.Cells[headersLocation[col.ColumnName].Item1 + i + 1,
                    headersLocation[col.ColumnName].Item2
                    ].Value = data.Rows[i][col];
            }
        }
    
        excelPackage.Save();
    }
