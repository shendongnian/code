    foreach (PropertyInfo info in properties)
    {
        if(info.PropertyType == typeof(IEnumerable))
        {
           dataTable.Columns.Add(new DataColumn(info.Name, info.Cast<object>().First().GetType());
        }
        else
        {
           dataTable.Columns.Add(new DataColumn(info.Name, info.PropertyType));
        }
    }
    foreach (T entity in list)
    {
        object[] values = new object[properties.Length];
        for (int i = 0; i < properties.Length; i++)
        {
            var v = properties[i].GetValue(entity);
            if(v is IEnumerable)
            {
              values[i] = (v.Cast<object>().First()).First();
            }
            else
            {
              values[i] = v;
            }
        }
        dataTable.Rows.Add(values);
    }
