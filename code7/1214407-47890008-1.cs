    private Cell InsertCell(uint rowIndex, uint columnIndex, Worksheet worksheet)
    {
        Row row = null;
        var sheetData = worksheet.GetFirstChild<SheetData>();
        // Check if the worksheet contains a row with the specified row index.
        row = sheetData.Elements<Row>().FirstOrDefault(r => r.RowIndex == rowIndex);
        if (row == null)
        {
            row = new Row() { RowIndex = rowIndex };
            sheetData.Append(row);
        }
        // Convert column index to column name for cell reference.
        var columnName = GetExcelColumnName(columnIndex);
        var cellReference = columnName + rowIndex;      // e.g. A1
        // Check if the row contains a cell with the specified column name.
        var cell = row.Elements<Cell>()
                   .FirstOrDefault(c => c.CellReference.Value == cellReference);
        if (cell == null)
        {
            cell = new Cell() { CellReference = cellReference };
            if (row.ChildElements.Count < columnIndex)
                row.AppendChild(cell);
            else
                row.InsertAt(cell, (int)columnIndex);
        }
        return cell;
    }
