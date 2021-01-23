        public static DataTable ToDataTable<T>(this IEnumerable<T> items, string tableName = "", bool treatItemAsValue = false)
        {
            // We want a single extension method that can take in an enumerable sequence (such as a LINQ query)
            // and return the result as a DataTable. We want this to be a one stop shop for converting
            // various objects into DataTable format, as DataTables are a nice parallel to Foxpro cursors.
            if (items == null) { return null; }
            Type itemType = typeof(T);
            bool typeIsNullable = itemType.IsGenericType && typeof(T).GetGenericTypeDefinition().Equals(typeof(Nullable<>));
            string itemTypeName = "";
            bool typeIsValue = false;
            Type itemUnderlyingType = itemType;
            if (typeIsNullable)
            {
                // Type of enumerable item is nullable, so we need to find its base type.
                itemUnderlyingType = Nullable.GetUnderlyingType(itemType);
            }
            typeIsValue = itemUnderlyingType.IsValueType;
            itemTypeName = itemUnderlyingType.Name;
            DataTable dt = new DataTable();
            DataColumn col = null;
            PropertyInfo[] props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            if ((treatItemAsValue) || (itemTypeName == "String") || (props.Length == 0))
            {
                // We have been asked to treat the item in the sequence as a value, or the items
                // in the sequence is a string which cannot be "flattened" properly by analyzing properties.
                // OR, the type has no properties to put on display, so we should just use the item directly.
                // (like the base "Object" type).
                typeIsValue = true;
            }
            if (itemTypeName == "DataRow")
            {
                // Special case. If our enumerable type is DataRow, then we can utilize a more appropriate
                // (built-in) extension method to convert enumerable DataRows to a DataTable.
                dt = ((IEnumerable<DataRow>)items).CopyToDataTable();
            }
            else
            {
                // We must have an enumerable sequence/collection of some other type, possibly anonymous.
                // Get properties of the enumerable to add as columns to the data table.
                if (typeIsValue)
                {
                    // Our enumerable items are of a value type (e.g. integers in a one-dimensional array).
                    col = dt.Columns.Add();
                    // Whether or not the type is nullable, the value might be null (e.g. for type "Object").
                    col.AllowDBNull = true;
                    col.ColumnName = itemTypeName;
                    col.DataType = itemUnderlyingType;
                    // Now walk through the enumeration and add rows to our data table (single values).
                    foreach (var item in items)
                    {
                        dt.Rows.Add(item);
                    }
                }
                else
                {
                    // The type should be something we can walk through the properties of in order to
                    // generate properly named and typed columns of our DataTable.
                    foreach (var prop in props)
                    {
                        Type propType = prop.PropertyType;
                        // Is it a nullable type? Get the underlying type.
                        if (propType.IsGenericType && propType.GetGenericTypeDefinition().Equals(typeof(Nullable<>)))
                        {
                            propType = new NullableConverter(propType).UnderlyingType;
                        }
                        dt.Columns.Add(prop.Name, propType);
                    }
                    // Now walk through the enumeration and add rows to our data table.
                    foreach (var item in items)
                    {
                        if (item != null)
                        {
                            // Can only add an item as a row if it is not null.
                            var values = new object[props.Length];
                            for (int i = 0; i < props.Length; i++)
                            {
                                values[i] = props[i].GetValue(item, null);
                            }
                            dt.Rows.Add(values);
                        }
                    }
                }
            }
            // Give the DataTable a reasonable name.
            if (tableName.Length == 0)
            {
                if (typeof(T).IsAnonymous())
                {
                    // Anonymous types have really goofy names, so there is no use using that as table name.
                    tableName = "Anonymous";
                }
                else
                {
                    // This is NOT an anonymous type, so we can use the type name as table name.
                    tableName = typeof(T).Name;
                }
            }
            return dt;
        }
