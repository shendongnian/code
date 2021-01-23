    public static void UpdateDataGridParameter(DataGrid dataGrid)
    {
        StringBuilder sb = new StringBuilder();
        var dataView = dataGrid.ItemsSource as DataView;
        var columnNames = dataView.Table.Columns
                .Cast<DataColumn>()
                .Select(column => column.ColumnName);
    
        sb.AppendLine(string.Join(",", columnNames));
                
        foreach (DataRowView row in dataView)
        {
            IEnumerable<string> fields = row.Row.ItemArray.Select(field => field.ToString());
            sb.AppendLine(string.Join(",", fields));
        }
    
        var filePath = @"C:\IO\" + dataGrid.Name + ".csv";
        File.WriteAllText(filePath, sb.ToString());
    }
