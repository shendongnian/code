    public static DataTable ToDataTable<T>(this System.Collections.Generic.List<T> collection, string _sTableName) {
			var table = new DataTable(_sTableName);
			var type = typeof(T);
			var properties = type.GetProperties();
			//Create the columns in the DataTable
			foreach (var property in properties) {
				if (property.PropertyType == typeof(int?)) {
					table.Columns.Add(property.Name, typeof(int));
				} else if (property.PropertyType == typeof(decimal?)) {
					table.Columns.Add(property.Name, typeof(decimal));
				} else if (property.PropertyType == typeof(double?)) {
					table.Columns.Add(property.Name, typeof(double));
				} else if (property.PropertyType == typeof(DateTime?)) {
					table.Columns.Add(property.Name, typeof(DateTime));
				} else if (property.PropertyType == typeof(Guid?)) {
					table.Columns.Add(property.Name, typeof(Guid));
				} else if (property.PropertyType == typeof(bool?)) {
					table.Columns.Add(property.Name, typeof(bool));
				} else {
					table.Columns.Add(property.Name, property.PropertyType);
				}
			}
			//Populate the table
			foreach (var item in collection) {
				var row = table.NewRow();
				row.BeginEdit();
				foreach (var property in properties) {
					row[property.Name] = property.GetValue(item, null) ?? DBNull.Value;
				}
				row.EndEdit();
				table.Rows.Add(row);
			}
			return table;
		}
