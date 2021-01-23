    public static class Common
        {
            /// <summary>
            ///  Convert IEnumerable<T> to DataTable
            /// </summary>
            /// <typeparam name="T"></typeparam>
            /// <param name="collection"></param>
            /// <returns></returns>
            public static DataTable CreateTable<T>(this IEnumerable<T> collection)
            {
                // Fetch the type of List contained in the ParamValue
                var tableType = typeof(T);
    
                // Create DataTable which will contain data from List<T>
                var dataTable = new DataTable();
    
                // Fetch the Type fields count
                int columnCount = tableType.GetProperties().Count();
    
                var columnNameMappingDictionary = new Dictionary<string, string>();
    
                // Create DataTable Columns using table type field name and their types
                // Traversing through Column Collection
                for (int counter = 0; counter < columnCount; counter++)
                {
                    var propertyInfo = tableType.GetProperties()[counter];
    
                    var parameterAttribute = propertyInfo.GetParameterAttribute();
    
                    string columnName = (parameterAttribute != null) ? parameterAttribute.Name : propertyInfo.Name;
    
                    columnNameMappingDictionary.Add(propertyInfo.Name,
                        (parameterAttribute != null) ? parameterAttribute.Name : propertyInfo.Name);
    
                    dataTable.Columns.Add(columnName, tableType.GetProperties()[counter].PropertyType);
                }
    
                // Return parameter with null value
                if (collection == null)
                    return dataTable;
    
                // Traverse through number of entries / rows in the List
                foreach (var item in collection)
                {
                    // Create a new DataRow
                    DataRow dataRow = dataTable.NewRow();
    
                    // Traverse through type fields or column names
                    for (int counter = 0; counter < columnCount; counter++)
                    {
                        // Fetch Column Name
                        string columnName = columnNameMappingDictionary[tableType.GetProperties()[counter].Name];
    
                        //Fetch Value for each column for each element in the List<T>
                        dataRow[columnName] = item
                            .GetType().GetProperties()[counter]
                            .GetValue(item);
                    }
                    // Add Row to Table
                    dataTable.Rows.Add(dataRow);
                }
    
                return (dataTable);
            }
    
            /// <summary>
            /// Convert IEnumerable<T> to DataTable
            /// </summary>
            /// <param name="paramValue"></param>
            /// <returns></returns>
            public static DataTable CreateTable(object paramValue)
            {
                // Fetch the type of List contained in the ParamValue
                Type tableType = paramValue.GetType().GetGenericArguments()[0];
    
                // Create DataTable which will contain data from List<T>
                var genericDataTable = new DataTable();
    
                // Fetch the Type fields count
                int fieldCount = tableType.GetProperties().Count();
    
                // Create DataTable Columns using table type field name and their types
                // Traversing through Column Collection
                for (int counter = 0; counter < fieldCount; counter++)
                {
                    genericDataTable.Columns.Add(tableType.GetProperties()[counter].Name,
                        tableType.GetProperties()[counter].PropertyType);
                }
    
                // Traverse through number of entries / rows in the List
                foreach (var item in (IEnumerable)paramValue)
                {
                    // Create a new DataRow
                    DataRow dataRow = genericDataTable.NewRow();
    
                    // Traverse through type fields or column names
                    for (int counter = 0; counter < fieldCount; counter++)
                    {
                        // Fetch Column Name
                        string columnName = tableType.GetProperties()[counter].Name;
    
                        //Fetch Value for each column for each element in the List<T>
                        dataRow[columnName] = item
                            .GetType().GetProperties()[counter]
                            .GetValue(item);
                    }
                    // Add Row to Table
                    genericDataTable.Rows.Add(dataRow);
                }
                return genericDataTable;
            }
    
            /// <summary>
            /// Convert DataTable to List<T>
            /// </summary>
            /// <typeparam name="T"></typeparam>
            /// <param name="dataTable"></param>
            /// <returns></returns>
            public static List<T> ToList<T>(DataTable dataTable) where T : new()
            {
                // Final result List (Converted from DataTable)
                var convertedList = new List<T>();
    
                // Traverse through Rows in the DataTable
                foreach (DataRow row in dataTable.Rows)
                {
                    // Type T of generic list object
                    var dataObject = new T();
    
                    // Traverse through Columns in the DataTable
                    foreach (DataColumn column in dataTable.Columns)
                    {
                        // Fetch column name
                        string fieldName = column.ColumnName;
    
                        // Fetch type PropertyInfo using reflection
                        var propertyInfo = dataObject.GetType()
                            .GetProperty(fieldName,
                                BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);
    
                        // For Null PropertyInfo, check whether ViewrColumn attribute is applied
                        propertyInfo = propertyInfo ?? Parameter.GetColumnAttribute(dataObject.GetType(), fieldName);
    
                        // Set the value for not null property Info
                        // Continue the loop for a null PropertyInfo (needs correction either in type description or DataTable selection)
                        if (propertyInfo == null) continue;
    
                        // Property value
                        var value = row[column];
    
                        // New - Work for Nullable Types
                        propertyInfo.SetValue(dataObject,
                            DataConversionMap.Map[propertyInfo.PropertyType](value), null);
                    }
    
                    // Add type object to the List
                    convertedList.Add(dataObject);
                }
    
                return (convertedList);
            }
        }
