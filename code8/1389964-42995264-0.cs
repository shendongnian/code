    var set = new DataSet();
    AddToDataSet(set, resp);
    
    ...
    public static void AddToDataSet(DataSet set, object value)
    {
        if (set == null)
            throw new ArgumentNullException(nameof(set));
        if (value == null)
            return;
        var type = value.GetType();
        var table = set.Tables[type.FullName];
        if (table == null)
        {
            // create one table per type (name)
            table = new DataTable(type.FullName);
            set.Tables.Add(table);
            foreach (var prop in type.GetProperties().Where(p => p.CanRead))
            {
                if (IsEnumerable(prop))
                    continue;
                var col = new DataColumn(prop.Name, prop.PropertyType);
                table.Columns.Add(col);
            }
        }
        var row = table.NewRow();
        foreach (var prop in type.GetProperties().Where(p => p.CanRead))
        {
            object propValue = prop.GetValue(value);
            if (IsEnumerable(prop))
            {
                if (propValue != null)
                {
                    foreach (var child in (ICollection)propValue)
                    {
                        AddToDataSet(set, child);
                    }
                }
                continue;
            }
            row[prop.Name] = propValue;
        }
        table.Rows.Add(row);
    }
    private static bool IsEnumerable(PropertyInfo pi)
    {
        // note: we could also use IEnumerable (but string, arrays are IEnumerable...)
        return typeof(ICollection).IsAssignableFrom(pi.PropertyType);
    }
