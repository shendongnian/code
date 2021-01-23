    public static class ExtensionHelper
	{
        public static System.Data.DataTable ToDataTable<T>(this IEnumerable<T> data)
        {
            var AllProperty = (typeof(T)).GetProperties().ToList();
            //var AllInsteadOf = InsteadOfProperty.Split('|').SkipWhile(i => string.IsNullOrEmpty(i));
            int propcount = AllProperty.Count();
            var table = new System.Data.DataTable();
            for (int i = 0; i < propcount; i++)
            {
                var prop = AllProperty[i];
                if (prop.CanRead)
                {
                    //If property type is Nullable<T> or It's a string type or it's a custom class theb
                    //column allowDBNull will be true
                    bool allowDBNull = false;
                    if ((prop.PropertyType.IsNullableType()) || (prop.PropertyType == typeof(String)) || (prop.PropertyType.IsCustomClass()))
                    {
                        allowDBNull = true;
                    }
                    table.Columns.Add(prop.Name, prop.PropertyType.GetCoreType()).AllowDBNull = allowDBNull;
                }
            }
            object[] values = new object[propcount];
            foreach (T item in data)
            {
                for (int i = 0; i < values.Length; i++)
                {
                    var prop = AllProperty[i];
                    if (prop.CanRead)
                    {
                        values[i] = prop.GetValue(item, null);
                    }
                }
                table.Rows.Add(values);
            }
            return table;
        }
        public static bool IsNullableType(this Type Value)
        {
            return (Value.IsGenericType && Value.GetGenericTypeDefinition() == typeof(Nullable<>));
        }
        public static bool IsCustomClass(this Type Value)
        {
            return !Value.Namespace.StartsWith("System");
        }
        /// <summary>
        /// Get underlying core type of a nullable data type
        /// </summary>
        /// <param name="Value">The value.</param>
        /// <returns>A Type object</returns>
        public static Type GetCoreType(this Type Value)
        {
            Type u = Nullable.GetUnderlyingType(Value);
            return u ?? Value;
        }
    }
