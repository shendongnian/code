	private static void SortList(string[] sortCols)
	{
		Console.WriteLine("Sorting test data");
		if (sortCols.Length < 1)
			return;
		IOrderedEnumerable<Data> returnVal = _testData.OrderBy(p => typeof(Data).GetProperty(sortCols[0]).GetValue(p, null));
		foreach (string col in sortCols.Skip(1))
		{
			returnVal = returnVal.ThenBy(p => typeof(Data).GetProperty(col).GetValue(p, null));
			//Or ThenByDescending
		}
		_testData = returnVal.ToList();
	}
