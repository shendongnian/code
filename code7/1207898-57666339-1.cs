    private void ReplaceByteColumns(DataTable table) {
        Dictionary<DataColumn, DataColumn> byteColumns = new Dictionary<DataColumn, DataColumn>();
        foreach (DataColumn column in table.Columns) {
            if ((column.DataType == typeof(byte[]))) {
                DataColumn byteColumn = new DataColumn();
                byteColumn.DataType = typeof(string);
                byteColumns.Add(column, byteColumn);
            }
            
        }
        
        foreach (DataColumn column in byteColumns.Keys) {
            DataColumn byteColumn = byteColumns[column];
            table.Columns.Add(byteColumn);
            foreach (DataRow row in table.Rows) {
                row.Item[byteColumn] = BitConverter.ToString(((byte[])(row.Item[column])));
            }
            
            byteColumn.SetOrdinal(column.Ordinal);
            byteColumn.ReadOnly = true;
            table.Columns.Remove(column);
            byteColumn.ColumnName = column.ColumnName;
        }
        
    }
