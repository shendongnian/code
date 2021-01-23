        DataTable newTable= new DataTable();
        // Make the columns of the new tables match the existing table columns
        foreach(DataColumn dc in table.Columns)
        {
            newTable.Columns.Add(new DataColumn(dc.ColumnName, dc.DataType));
            newTable.Columns.Add(new DataColumn(dc.ColumnName, dc.DataType));
        }
