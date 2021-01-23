    private static DataTable GetDataTable<T>(IEnumerable<T> data, int skip, int take)
            {
                var properties = TypeDescriptor.GetProperties(typeof(T));
    
                var dataTable = new DataTable();
                foreach (PropertyDescriptor prop in properties)
                    dataTable
                        .Columns
                        .Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType)
                                        ?? prop.PropertyType);
    
                foreach (var item in data.Skip(skip).Take(take))
                {
                    var row = dataTable.NewRow();
                    foreach (PropertyDescriptor prop in properties)
                        row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
    
                    dataTable.Rows.Add(row);
                }
                return dataTable;
            }
