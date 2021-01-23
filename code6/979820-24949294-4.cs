	public static DataTable FullOuterJoin<T>(this DataTable table1, DataTable table2, Func<DataRow, T> keygen)
	{
		// perform inital outer join operation
		var outerjoin = 
			(
				from row1 in table1.AsEnumerable()
				join row2 in table2.AsEnumerable() 
					on keygen(row1) equals keygen(row2)
					into matches
				from row2 in matches.DefaultIfEmpty()
				select new { key = keygen(row1), row1, row2 }
			).Union(
				from row2 in table2.AsEnumerable()
				join row1 in table1.AsEnumerable()
					on keygen(row2) equals keygen(row1)
					into matches
				from row1 in matches.DefaultIfEmpty()
				select new { key = keygen(row2), row1, row2 }
			);
	
		// Create result table
		DataTable result = new DataTable();
		result.Columns.Add("__key", typeof(string));
		foreach (var col in table1.Columns.OfType<DataColumn>())
			result.Columns.Add("T1_" + col.ColumnName, col.DataType);
		foreach (var col in table2.Columns.OfType<DataColumn>())
			result.Columns.Add("T2_" + col.ColumnName, col.DataType);
		
		// fill table from join query
		var row1def = new object[table1.Columns.Count];
		var row2def = new object[table2.Columns.Count];
		foreach (var src in outerjoin)
		{
			// extract values from each row where present
			var data1 = (src.row1 == null ? row1def : src.row1.ItemArray);
			var data2 = (src.row2 == null ? row2def : src.row2.ItemArray);
			
			// create row with key string and row values
			result.Rows.Add(new object[] { src.key.ToString() }.Concat(data1).Concat(data2).ToArray());
		}
	
		return result;
	}
