    // Columns
                int rowIndex = 1;
                int colIndex = 1;
                foreach (DataColumn dc in table.Columns) //Creating Headings
                {
                    var cell = ws.Cells[rowIndex, colIndex];
    
                    //Setting the background color of header cells to Gray
                    var fill = cell.Style.Fill;
                    fill.PatternType = ExcelFillStyle.Solid;
                    fill.BackgroundColor.SetColor(Color.LightGray);
    
                    //Setting Top/left,right/bottom borders.
                    var border = cell.Style.Border;
                    border.Bottom.Style = border.Top.Style = border.Left.Style = border.Right.Style = ExcelBorderStyle.Thin;
    
                    //Setting Value in cell
                    cell.Value = dc.ColumnName;
    
                    colIndex++;
                }
    
                // Rows
                int col = 1;
                int row = 2;
                foreach (DataRow rw in table.Rows)
                {
                    foreach (DataColumn cl in table.Columns)
                    {
                        if (rw[cl.ColumnName] != DBNull.Value)
                            ws.Cells[row, col].Value = rw[cl.ColumnName].ToString();
                        col++;
                    }
                    row++;
                    col = 1;
                }
    
                pack.SaveAs(Result);
                return Result;
