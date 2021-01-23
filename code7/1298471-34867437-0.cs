            DataTable table = new DataTable();
            DataColumn column;
            DataRow row;
            DataView view;
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.Int32");
            column.ColumnName = "id";
            table.Columns.Add(column);
            column = new DataColumn();
            column.DataType = Type.GetType("System.String");
            column.ColumnName = "name";
            table.Columns.Add(column);
            // Create new DataRow objects and add to DataTable.    
            for (int i = 0; i < 5; i++)
            {
                row = table.NewRow();
                row["id"] = i;
                row["name"] = "Name " + i.ToString();
                table.Rows.Add(row);
            }
            dataGrid1.ItemsSource = table.DefaultView;
     
