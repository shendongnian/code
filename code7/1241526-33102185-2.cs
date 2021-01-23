        private DataTable getDataTableFromExcel(string path)
        {
            using (var pck = new OfficeOpenXml.ExcelPackage())
            {
                using (var stream = File.OpenRead(path))
                {
                    pck.Load(stream);
                }
                var ws = pck.Workbook.Worksheets.First();
                DataTable dt = new DataTable();
                bool hasHeader = true;
                int headercol = 1;
                int rownumber = 1;
                try
                {
                    foreach (var firstRowCell in ws.Cells[1, 1, 1, ws.Dimension.End.Column])
                    {
                        dt.Columns.Add(headercol.ToString());
                        headercol++;
                    }
                    var startRow = hasHeader ? 2 : 1;
    
                    for (var rowNum = startRow; rowNum <= ws.Dimension.End.Row; rowNum++)
                    {
                        var wsRow = ws.Cells[rowNum, 1, rowNum, 38]; //last parameter is colums count, here i fixed it to 38 
                        var row = dt.NewRow();
                        foreach (var cell in wsRow)
                        {
                            row[cell.Start.Column - 1] = cell.Text;
                        }
                        dt.Rows.Add(row);
                        rownumber++;
                    }
                    return dt;
                }
                catch (Exception x)
                {
                   // throw new Exception(x + " on row " + rownumber);
                    return null;//Used null, But Log your exception here. 
                }
                
            }
        }
