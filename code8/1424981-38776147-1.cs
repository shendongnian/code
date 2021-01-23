    public IEnumerable<IGrouping<IEnumerable<string>, Row>> GroupData(IEnumerable<int> columnIndexes = null)
    {
    	if (columnIndexes == null) columnIndexes = Enumerable.Empty<int>();
    	return Data.GroupBy(r => columnIndexes.Select(c => r.Columns[c]), ColumnEqualityComparer.Instance);
    }
