    /// <summary>
	/// Deletes empty rows and columns from the end of the given worksheet
	/// </summary>
	public static void Trim(this Excel.Worksheet worksheet)
	{
		worksheet.TrimColumns();
		worksheet.TrimRows();
	}
	/// <summary>
	/// Deletes empty rows from the end of the given worksheet
	/// </summary>
	public static void TrimRows(this Excel.Worksheet worksheet)
	{
        Excel.Range range = worksheet.UsedRange;
        while(worksheet.Application.WorksheetFunction.CountA(range.Rows[range.Rows.Count]) == 0)
			(range.Rows[range.Rows.Count] as Excel.Range).Delete();
	}
	/// <summary>
	/// Deletes empty columns from the end of the given worksheet
	/// </summary>
	public static void TrimColumns(this Excel.Worksheet worksheet)
	{
		Excel.Range range = worksheet.UsedRange;
		while(worksheet.Application.WorksheetFunction.CountA(range.Columns[range.Columns.Count]) == 0)
			(range.Columns[range.Columns.Count] as Excel.Range).Delete();
	}
