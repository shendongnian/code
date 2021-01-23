    const int MaxCells = 1 * 1024 * 1024; // Arbitrary
    var maxColumns = parsedData.Max(data => data.Length);
    var maxRows = Math.Min(parsedData.Count, MaxCells / maxColumns);
    object[,] values = null;
    int row = 1, column = 1;
    for (int lstElement = 0; lstElement < parsedData.Count; )
    {
    	int rowCount = Math.Min(maxRows, parsedData.Count - lstElement);
    	if (values == null || values.GetLength(0) != rowCount)
    		values = new object[rowCount, maxColumns];
    	for (int r = 0; r < rowCount; r++)
    	{
    		var data = parsedData[lstElement++];
    		for (int c = 0; c < data.Length; c++)
    			values[r, c] = data[c];
    	}
    	var range = sheet.Range[CellName(row, column), CellName(row + rowCount - 1, column + maxColumns - 1)];
    	range.Value2 = values;
    	row += rowCount;
    }
