    public static List<T> DataReaderMapToList<T>(this IDataReader dr)
        {
            var list = new List<T>();
            var obj = default(T);
            var columns = dr.GetSchemaTable().Rows;
            var columnsArray = new DataRow[columns.Count];
            columns.CopyTo(columnsArray, 0);
            var columnNames = columnsArray.Select(x => x[0].ToString());
            while (dr.Read())
            {
                obj = Activator.CreateInstance<T>();
                var type = obj.GetType();
                foreach (var column in columnNames)
                {
                    var field = type.GetField(column);
                    if (field != null && dr[column].GetType().FullName == field.FieldType.FullName)
                    {
                        field.SetValue(obj, dr[column], BindingFlags.SetField, null, null);
                        continue;
                    }
                    var property = type.GetProperty(column);
                    if (property != null && dr[column].GetType().FullName == property.PropertyType.FullName)
                    {
                        property.SetValue(obj, dr[column]);
                    }
                }
                list.Add(obj);
            }
            return list;
        }
