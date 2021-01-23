    Type colType = Dataset.Tables[0].Columns["B"].DataType;
    object defaultValue = colType.IsValueType ?  Activator.CreateInstance(bType) : null;
    foreach (DataRow row in Dataset.Tables[0].Rows)
    {
        row.SetField("B", defaultValue); 
    }
