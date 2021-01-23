    public static DataSet Validator(DataSet dataSet)
    {
        foreach (DataTable dataTable in dataSet.Tables)
            foreach (DataRow dataRow in dataTable.Rows)
                foreach (DataColumn dataDataColumn in dataTable.Columns)
                    if (dataRow.IsNull(dataDataColumn))
                        dataRow[dataDataColumn] = GetDefaultValue(dataDataColumn.DataType);
                    
        return dataSet;
    }
        
    static object GetDefaultValue(Type t)
    {
        // get the default value for value types
        if (t.IsValueType)
            return Activator.CreateInstance(t);
        
        // in case of a string, we want an empty one instead of null
        if (t == typeof(string))
            return String.Empty;
    
        return null;
    }
