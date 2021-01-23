    for (int i = 0; i < schema.Rows.Count; i++)
    {
        var name = (string)schema.Rows[i]["ColumnName"];
        var allowNulls = (bool)schema.Rows[i]["AllowDBNull"];
        Type type = (Type)schema.Rows[i]["DataType"];
    
        if (allowNulls)
        {
             type = typeof(Nullable<>).MakeGenericType(type);
        }
       
    }
