	public static bool IsCellAfterColumn(string cellReference, string newCellReference)
	{
		var columnNameRegex = new Regex("[A-Za-z]+");
		var cellReference = cell.CellReference.Value;
		var cellColumn = columnNameRegex.Match(cellReference).Value;
		var newCellColumn = columnNameRegex.Match(cellReference).Value;
		var cellColumnLength = cellColumn.Length;
		var newCellColumnLength = newCellColumn.Length;
		if (cellColumnLength > columnLettersLength)
		{
			return true;
		}
		if (cellColumnLength < columnLettersLength)
		{
			return false;
		}
		var comparisonValue = string.Compare(cellColumn, newCellColumn, StringComparison.OrdinalIgnoreCase);
		return comparisonValue > 0;
	}
