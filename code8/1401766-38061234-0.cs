    for (var row = 1; row <= tbl.Rows.Count; row++)
    {
        for (var column = 1; column <= tbl.Columns; column++)
        {
            ws.Cells[row, column].Style.Font.Bold = false;
            ws.Cells[row, column].Style.Fill.PatternType = ExcelFillStyle.Solid;
            ws.Cells[row, column].Style.Font.Size = 10;
            ws.Cells[row, column].Style.Fill.BackgroundColor.SetColor(column%2 == 0
               ? Color.Blue
               : Color.Gray);
         }
    }
