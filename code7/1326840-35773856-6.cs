    public static DataTable ConvertListToDataTable(ICollection<IDataRowConvertible> list){
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
