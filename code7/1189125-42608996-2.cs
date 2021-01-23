    // usage: LoadFormulasFromArrays(ws.Cells, row, col, MyListOfObjectArrays)
    public ExcelRangeBase LoadFormulasFromArrays(ExcelRange Cells, int _fromRow, int _fromCol, IEnumerable<object[]> Data)
    {
        //thanx to Abdullin for the code contribution
        ExcelWorksheet _worksheet = Cells.Worksheet;
        if (Data == null) throw new ArgumentNullException("data");
        int column = _fromCol, row = _fromRow;
        foreach (var rowData in Data)
        {
            column = _fromCol;
            foreach (var cellData in rowData)
            {
                Cells[row, column].Formula = cellData.ToString();
                column += 1;
            }
            row += 1;
        }
        return Cells[_fromRow, _fromCol, row - 1, column - 1];
    }
