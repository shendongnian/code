	public static Cell GetFirstFollowingCell(Row row, string newCellReference)
	{
		var rowCells = row.Elements<Cell>();
		return rowCells.FirstOrDefault(c => IsCellAfterColumn(c.CellReference.Value, newCellReference));
	}
