     public static DataTable CreateTable<TDataTable>(this IEnumerable<TDataTable> collection)
            {
                // Fetch the type of List contained in the ParamValue
                var tableType = typeof(TDataTable);
    
                // Create DataTable which will contain data from List<T>
                var dataTable = new DataTable();
    
                // Fetch the Type fields count
                var columnCount = tableType.GetProperties().Count();
    
                var columnNameMappingDictionary = new Dictionary<string, string>();
    
                // Create DataTable Columns using table type field name and their types
                // Traversing through Column Collection
                for (var counter = 0; counter < columnCount; counter++)
                {
                    var propertyInfo = tableType.GetProperties()[counter]; 
                    
                    var columnName = propertyInfo.Name;
    
                    columnNameMappingDictionary.Add(propertyInfo.Name,
                        propertyInfo.Name);
    
                    // Fetch the current type of a property and check whether its nullable type before adding a column
                    var currentType = tableType.GetProperties()[counter].PropertyType;
    
                    dataTable.Columns.Add(columnName, Nullable.GetUnderlyingType(currentType) ?? currentType);
                }
    
                // Return parameter with null value
                if (collection == null)
                    return dataTable;
    
                // Traverse through number of entries / rows in the List
                foreach (var item in collection)
                {
                    // Create a new DataRow
                    var dataRow = dataTable.NewRow();
    
                    foreach (var columnName in columnNameMappingDictionary.Select(propertyinfo => propertyinfo.Value))
                    {
                        dataRow[columnName] = item.GetType().GetProperty(columnName).GetValue(item) ?? DBNull.Value;
                    }
                    // Add Row to Table
                    dataTable.Rows.Add(dataRow);
                }
    
                return (dataTable);
            }
