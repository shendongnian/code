    int i = 0;    
    // For each table in the DataSet, print the row values.
    foreach(DataTable table in ds.Tables)
    {
        foreach(DataRow row in table.Rows)
        {
            foreach (DataColumn column in table.Columns)
            {
                as[i]=row[column]);
                i++;
            }
        }
    }
