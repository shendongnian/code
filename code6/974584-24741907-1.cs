    var pck = new OfficeOpenXml.ExcelPackage();
    pck.Load(new System.IO.FileInfo(path).OpenRead());
    var ws = pck.Workbook.Worksheets["Worksheet1"];
    DataTable tbl = new DataTable();
    var hasHeader = true;
    foreach (var firstRowCell in ws.Cells[1, 1, 1, ws.Dimension.End.Column]){
      tbl.Columns.Add(hasHeader ? firstRowCell.Text : string.Format("Column {0}",         firstRowCell.Start.Column));
    }
    var startRow = hasHeader ? 2 : 1;
    for (var rowNum = startRow; rowNum <= ws.Dimension.End.Row; rowNum++){
     var wsRow = ws.Cells[rowNum, 1, rowNum, ws.Dimension.End.Column];
     var row = tbl.NewRow();
     foreach (var cell in wsRow){
           row[cell.Start.Column - 1] = cell.Text;
     }
     tbl.Rows.Add(row);
    }
