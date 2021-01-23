	public static Cell GetFirstFollowingCell(Row row, string newCellReference)
	{
		var rowCells = row.Elements<Cell>();
		return rowCells.FirstOrDefault(c => IsNewCellAfterCurrentCell(c.CellReference.Value, newCellReference));
	}
