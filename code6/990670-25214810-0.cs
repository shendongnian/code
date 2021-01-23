    public static class DataTableExtensions
	{
		public static IEnumerable<string> GetDataInColumn(this DataColumn column)
		{
			return column.Table.Rows.Cast<DataRow>().Select(row => row[column.ColumnName].ToString());
		}
	}
