    //Get the primarykey column names
    List<string> names = dt.PrimaryKey
                           .Cast<DataColumn>()
                           .Select(x => x.ColumnName)
                           .ToList();
    // New table
    DataTable dt2 = dt.Copy();
    // Get the array of datacolumns that match the name of the other table primary
    DataColumn[] keys = dt2.Columns
                           .Cast<DataColumn>()
                           .Where(x => names.Contains(x.ColumnName))
                           .ToArray();
    // Set the primary in the copied table
    dt2.PrimaryKey = keys;
