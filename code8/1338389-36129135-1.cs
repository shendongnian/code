    public static DataTable LINQtoDataTable<T>(this IEnumerable<T> data)
    {
        DataTable dt = new DataTable();
        PropertyInfo[] objectProps = null; // Reflection
        if (data == null) return null;
        foreach (T record in data)
        {
            if (objectProps == null) objectProps = ((Type)data.GetType()).GetProperties();
            foreach (PropertyInfo pi in objectProps)
            {
                Type collumnType = pi.PropertyType;
                if ((collumnType.IsGenericType) && (collumnType.GetGenericTypeDefinition() == typeof(Nullable<>))) collumnType = collumnType.GetGenericArguments()[0];
                dt.Columns.Add(new DataColumn(pi.Name, collumnType));
            }
        }
        return dt;
    }
