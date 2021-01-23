     using (var pck = new OfficeOpenXml.ExcelPackage(file))
     {
         List<string> sheets = pck.Workbook.Worksheets.Select(x=>x.Name).ToList();
         var ws = pck.Workbook.Worksheets[sheet];
         DataTable tbl = new DataTable();
    
         foreach (var firstRowCell in ws.Cells[1, 1, 1, ws.Dimension.End.Column])
         {
              tbl.Columns.Add(hasHeader ? firstRowCell.Text : string.Format("Column {0}", firstRowCell.Start.Column));
         }
         var startRow = hasHeader ? 2 : 1;
         for (var rowNum = startRow; rowNum <= ws.Dimension.End.Row; rowNum++)
         {
             var wsRow = ws.Cells[rowNum, 1, rowNum, tbl.Columns.Count];
             var row = tbl.NewRow();
             foreach (var cell in wsRow)
             {
                 row[cell.Start.Column - 1] = cell.Text;
             }
             tbl.Rows.Add(row);
         }
         return tbl;
     }
