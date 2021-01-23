    DataTable Pivot(DataTable table, string pivotColumnName)
    {
        // TODO make sure the table contains at least two columns
        
         // get the data type of the first value column
        var dataType = table.Columns[1].DataType;
        
        // create a pivoted table, and add the first column
        var pivotedTable = new DataTable();
        pivotedTable.Columns.Add("Row Name", typeof(string));
        
        // determine the names of the remaining columns of the pivoted table
        var additionalColumnNames = table
            .AsEnumerable()
            .Select(x => x[pivotColumnName].ToString());
        
        // add the remaining columns to the pivoted table
        foreach (var columnName in additionalColumnNames)
            pivotedTable.Columns.Add(columnName, dataType);
            
        // determine the row names for the pivoted table
        var rowNames = table.Columns
            .Cast<DataColumn>()
            .Select(x => x.ColumnName)
            .Where(x => x != pivotColumnName);
    
        // fill in the pivoted data
        foreach (var rowName in rowNames)
        {
            var pivotedData = table
                .AsEnumerable()
                .Select(x => x.Field<object>(rowName));
            var data = new object[] { rowName }.Concat(pivotedData).ToArray();
            pivotedTable.Rows.Add(data);
        }
        return pivotedTable;
    }
