	public static bool IsNewCellAfterCurrentCell(string currentCellReference, string newCellReference)
	{
		var columnNameRegex = new Regex("[A-Za-z]+");
		var currentCellColumn = columnNameRegex.Match(currentCellReference).Value;
		var newCellColumn = columnNameRegex.Match(newCellReference).Value;
		var currentCellColumnLength = currentCellColumn.Length;
		var newCellColumnLength = newCellColumn.Length;
		if (currentCellColumnLength == newCellColumnLength)
		{
			var comparisonValue = string.Compare(currentCellColumn, newCellColumn, StringComparison.OrdinalIgnoreCase);
			return comparisonValue > 0;
		}
		return currentCellColumnLength < newCellColumnLength;
	}
