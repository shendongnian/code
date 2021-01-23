    foreach (DataRow row in dt.Rows)
    {
        foreach (DataColumn column in dt.Columns)
        {
            if (column.Ordinal != 1)
            {
                //Add the Data rows.
                txt += row[column.ColumnName].ToString() + "|";
            }
        }
        //...
    }
