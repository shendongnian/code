    private DataColumn AddColumn(string columnName, Type columnType)
    {
        // Remove the [ ] from the values:
        var col = column.Substring(1, columnName.Length - 2);
        DataColumn dataColumn = new DataColumn(col, columnType);
        dataColumn.AllowDBNull = true;
        return dataColumn;
    }
    
    if (row == 5)
    {
        csvData.Columns.Add(AddColumn(rowData[0], typeof(string)));
        csvData.Columns.Add(AddColumn(rowData[1], typeof(int)));
        csvData.Columns.Add(AddColumn(rowData[2], typeof(DateTime)));
        csvData.Columns.Add(AddColumn(rowData[3], typeof(string)));
        // etc
    }
