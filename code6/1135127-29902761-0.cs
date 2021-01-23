    private static DataTable AddColumnsForProperties(string myNamespace, DataTable dt, List<PropertyDescriptor> p, ref List<PropertyDescriptor[]> properties)
    {
        var pLast = p.Last();
        if (pLast.PropertyType.Namespace.StartsWith(myNamespace))
        {
            var allProperties = pLast.GetChildProperties();
            foreach (PropertyDescriptor item in allProperties)
            {
                var newP = p.ToList();
                newP.Add(item);
                if (item.PropertyType.Namespace.ToLower().StartsWith(myNamespace))
                    AddColumnsForProperties(myNamespace, dt, newP, ref properties);
                else
                    if (!dt.Columns.Contains(item.Name))
                    {
                        dt.Columns.Add(item.Name, Nullable.GetUnderlyingType(item.PropertyType) ?? item.PropertyType);
                        properties.Add(newP.ToArray());
                    }
            }
        }
        else
            if (!dt.Columns.Contains(pLast.Name))
            {
                dt.Columns.Add(pLast.Name, Nullable.GetUnderlyingType(pLast.PropertyType) ?? pLast.PropertyType);
                properties.Add(p.ToArray());
            }
        return dt;
    }
    static object GetValueFromProps(PropertyDescriptor[] descriptors, object item)
    {
        var result = item;
        foreach (var descriptor in descriptors)
        {
            result = descriptor.GetValue(result);
        }
        return result;
    }
    public static DataTable ToDataTable<T>(this IList<T> list)
    {
        DataTable table = null;
        if (list != null && list.Count > 0)
        {
            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(typeof(T));
            List<PropertyDescriptor[]> propList = new List<PropertyDescriptor[]>();
            table = new DataTable();
            foreach (PropertyDescriptor item in properties)
            {
                AddColumnsForProperties(typeof(T).Namespace, table, (new[] { item }).ToList(), ref propList);
            }
            object[] values = new object[propList.Count];
            foreach (T item in list)
            {
                for (int i = 0; i < values.Length; i++)
                    values[i] = GetValueFromProps(propList[i], item) ?? DBNull.Value;
                table.Rows.Add(values);
            }
        }
        return table;
    }
