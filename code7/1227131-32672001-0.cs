    private static DataTable LinqQueryToDataTable(IEnumerable<dynamic> v)
    {
        var firstRecord = v.FirstOrDefault();
        if (firstRecord == null)
            return null;
        var infos = ListBindingHelper.GetListItemProperties(v);
        DataTable table = new DataTable();
        foreach (PropertyDescriptor info in infos)
        {
            Type propType = info.PropertyType;
    
            if (propType.IsGenericType
                && propType.GetGenericTypeDefinition() == typeof(Nullable<>))
            {
                table.Columns.Add(info.Name, Nullable.GetUnderlyingType(propType));
            }
            else
            {
                table.Columns.Add(info.Name, info.PropertyType);
            }
        }
        DataRow row;
        foreach (var record in v)
        {
            row = table.NewRow();
            for (int i = 0; i < table.Columns.Count; i++)
            {
                row[i] = infos[i].GetValue(record) ?? DBNull.Value;
            }
    
            table.Rows.Add(row);
        }
        table.AcceptChanges();
        return table;
    }
