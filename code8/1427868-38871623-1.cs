    var usedRange = worksheet.UsedRange;
    int startRow = usedRange.Row;
    int endRow = startRow + usedRange.Rows.Count - 1;
    int startColumn = usedRange.Column;
    int endColumn = startColumn + usedRange.Columns.Count - 1;
    for (int row = startRow; row <= endRow; row++)
    {
    	Excel.Range lastCell = worksheet.Cells[row, endColumn];
    	if (lastCell.Value2 == null)
    		lastCell = lastCell.End[Excel.XlDirection.xlToLeft];
    	var lastColumn = lastCell.Column;
    	Console.WriteLine($"{row}: {lastColumn}");
    }
