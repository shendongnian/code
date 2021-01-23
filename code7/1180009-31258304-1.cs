    for (int i = 0; i < schema.Rows.Count; i++)
    {
        var name = (string)schema.Rows[i]["ColumnName"];
        var allowNulls = (bool)schema.Rows[i]["AllowDBNull"];
        Type type = (Type)schema.Rows[i]["DataType"];
    
        // Add a condition to check value type. e.g. string should be non-nullable
        // SQL data type should be all non-generic, skip check
        if (allowNulls && type.IsValueType)
        {
             type = typeof(Nullable<>).MakeGenericType(type);
        }
       
    }
