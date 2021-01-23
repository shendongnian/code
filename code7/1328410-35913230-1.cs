    /// <summary>Compares the values of each row in the provided DataTables and returns any rows that have a difference based on a provided 'key' column.</summary>
    /// <param name="left">the 'pre' data.</param>
    /// <param name="right">the 'post' data.</param>
    /// <param name="keyColumn">Name of the column to use for matching rows.</param>
    /// <returns>New DataTable populated with difference rows only.</returns>
    public DataTable Compare(DataTable left, DataTable right, string keyColumn)
    {
    	const string Pre = "_Pre";
    	const string Post = "_Post";
    
    	DataColumn leftKey = left.Columns.Contains(keyColumn) ? left.Columns[keyColumn] : null;
    	DataColumn rightKey = right.Columns.Contains(keyColumn) ? right.Columns[keyColumn] : null;
    
    	if (leftKey == null || rightKey == null)
    	{
    		return null;
    	}
    
    	// Get the matching columns between the two tables for doing comparisons.
    	List<string> comparisonColumns = new List<string>();
    	DataTable results = new DataTable();
    	// Adding the key column to the front for sake of ease of viewing.
    	results.Columns.Add(new DataColumn(leftKey.ColumnName, leftKey.DataType));
    	foreach (DataColumn column in left.Columns)
    	{
    		if(column == leftKey)
    		{
    			continue;
    		}
    
    		// Remove any columns that are not present in the compare table.
    		foreach (DataColumn compareColumn in right.Columns)
    		{
    			if (column.ColumnName == compareColumn.ColumnName && column.DataType == compareColumn.DataType)
    			{
    				comparisonColumns.Add(column.ColumnName);
    				results.Columns.Add(new DataColumn(column.ColumnName + Pre, column.DataType));
    				results.Columns.Add(new DataColumn(column.ColumnName + Post, column.DataType));
    				break;
    			}
    		}
    	}
    
    	foreach (DataRow leftRow in left.Rows)
    	{
    		object key = leftRow.Field<object>(leftKey);
    		string filterExpression = string.Format("{0} = {1}", keyColumn, key);
    		DataRow rightRow = right.Select(filterExpression).SingleOrDefault();
    		// Need a row for a comparison to be valid.
    		if (rightRow == null)
    		{
    			continue;
    		}
    
    		List<object> comparison = new List<object>();
    		comparison.Add(key);
    		bool isDiff = false;
    		foreach (string comparisonColumn in comparisonColumns)
    		{
    			object pre = leftRow.ItemArray[left.Columns.IndexOf(comparisonColumn)];
    			comparison.Add(pre);
    			object post = rightRow.ItemArray[right.Columns.IndexOf(comparisonColumn)];
    			comparison.Add(post);
    
    			// Only need the row if the values differ in at least one column.
    			isDiff |= (pre == null && post != null) || (pre != null && post == null) || (!pre.Equals(post));
    		}
    		if (isDiff)
    		{
    			results.Rows.Add(comparison.ToArray());
    		}
    	}
    
    	return results;
    }
