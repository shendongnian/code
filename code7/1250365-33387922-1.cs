    public static object[] ExtractColumn(ResponseRow[] responseRows, int columnIndex)
	{
		if (columnIndex < 0)
		{
			return null;
		}
        if (responseRows.Any(x => x.RowData[columnIndex] is DateTime))
        {
            return responseRows.Select(x => Convert.ToDateTime(x.RowData[columnIndex]).Date).Cast<object>().ToArray();                
        }
		return responseRows.Select(x => x.RowData[columnIndex]).ToArray();
	}
