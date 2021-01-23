            DataTable table = GetDataTable();
            foreach (DataColumn column in table.Columns)
            {
                var name = column.ColumnName;  // the column name
                var type = column.DataType.ToString();  // the type as string
                
            }
