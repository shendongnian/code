    public static DataTable ConvertListToDataTable<T>(ICollection<T> list) where T: IDataRowConvertible
    {
		if (list.Count > 0)
		{
			var table = new DataTable();
			list.First().DefineColumns(table.Columns);
			foreach (var item in list)
			{
				var row = table.NewRow();
				item.WriteToRow(row);
				table.Rows.Add(row);
			}
			return table;
		}
		return null;
    }
