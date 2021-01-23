    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
            {
                if (value == null)
                    return null;
    
                var dataTable = value as DataTable;
                
                if (dataTable != null)
                {
                    var columnsList = (from object column in dataTable.Columns select column.ToString()).ToList();
    
                    columnsList = columnsList.OrderBy(col => col).ToList();
    
                    for (var i = 0; i < columnsList.Count; i++)
                    {
                        dataTable.Columns[columnsList[i]].SetOrdinal(i);
                    }
    
                    return dataTable;
                }
    
                return value;
            }
