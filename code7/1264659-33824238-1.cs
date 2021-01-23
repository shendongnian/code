    public DataTable CreateNestedDataTable<TOuter, TInner>(IEnumerable<TOuter> list, string innerListPropertyName)
    {
        PropertyInfo[] outerProperties = typeof(TOuter).GetProperties().Where(pi => pi.Name != innerListPropertyName).ToArray();
        PropertyInfo[] innerProperties = typeof(TInner).GetProperties();
        MethodInfo innerListGetter = typeof(TOuter).GetProperty(innerListPropertyName).GetMethod;
        // set up columns
        DataTable table = new DataTable();
        foreach (PropertyInfo pi in outerProperties)
            table.Columns.Add(pi.Name, Nullable.GetUnderlyingType(pi.PropertyType) ?? pi.PropertyType);
        foreach (PropertyInfo pi in innerProperties)
            table.Columns.Add(pi.Name, Nullable.GetUnderlyingType(pi.PropertyType) ?? pi.PropertyType);
        // iterate through outer items
        foreach (TOuter outerItem in list)
        {
            var innerList = innerListGetter.Invoke(outerItem, null) as IEnumerable<TInner>;
            if (innerList == null || innerList.Count() == 0)
            {
                // outer item has no inner items
                DataRow row = table.NewRow();
                foreach (PropertyInfo pi in outerProperties)
                    row[pi.Name] = pi.GetValue(outerItem) ?? DBNull.Value;
                table.Rows.Add(row);
            }
            else
            {
                // iterate through inner items
                foreach (object innerItem in innerList)
                {
                    DataRow row = table.NewRow();
                    foreach (PropertyInfo pi in outerProperties)
                        row[pi.Name] = pi.GetValue(outerItem) ?? DBNull.Value;
                    foreach (PropertyInfo pi in innerProperties)
                        row[pi.Name] = pi.GetValue(innerItem) ?? DBNull.Value;
                    table.Rows.Add(row);
                }
            }
        }
        return table;
    }
