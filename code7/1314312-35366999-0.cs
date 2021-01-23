	//Loop through arrays in parsedData list.
	int row = 1, column = 1;
	object[] values = null; // buffer - see below. Avoids unnecessary allocations.
	for (var lstElement = 0; lstElement < parsedData.Count; lstElement++)
	{
		var data = parsedData[lstElement];
		if (data == null || data.Length == 0) continue;
		if (data.Length == 1)
		{
			// Single cell
			sheet.Cells[row, column] = data[0];
		}
		else
		{
			// Cell range
			var range = sheet.Range[CellName(row, column), CellName(row, column + data.Length - 1)];
			// We can pass the data array directly, but since it's a string[], Excel will treat them as text.
			// The trick is to to pass them via object[].
			if (values == null || values.Length != data.Length)
				values = new object[data.Length];
			for (int i = 0; i < data.Length; i++)
				values[i] = data[i];
			// Set all values in a single roundtrip
			range.Value2 = values;
		}
		row++;
	}
