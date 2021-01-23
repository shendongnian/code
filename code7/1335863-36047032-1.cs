    //get all the column names for the table to build mapping object
    SqlCommand command = new SqlCommand($"SELECT TOP 1 * FROM {foundTableName}", conn);
    SqlDataReader reader = command.ExecuteReader();
    //build mapping object by iterating through rows and verifying that there is a match in the table
    var mapper = new List<Tuple<string, Func<object, string, object>>>();
    foreach (DataRow col in reader.GetSchemaTable().Rows)
    {
        //get column information
        string columnName = col.Field<string>("ColumnName");
        PropertyInfo property = typeof(T).GetProperty(columnName);
        Func<object, string, object> map;
        if (property == null)
        {
            //check if it's nullable and exit if not
            bool nullable = col.Field<bool>("Is_Nullable");
            if (!nullable)
                return $"No corresponding property found for Non-nullable field '{columnName}'.";
            //if it's nullable, create mapping function
            map = new Func<object, string, object>((a, b) => null);
        }
        else
            map = new Func<object, string, object>((src, fld) => typeof(T).GetProperty(fld).GetValue(src));
        //add mapping object
        mapper.Add(new Tuple<string, Func<object, string, object>>(columnName, map));
    }
