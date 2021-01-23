    string[] columnNames = dtPlatypusResults.Columns.Cast<DataColumn>()
                                 .Select(x => x.ColumnName)
                                 .ToArray();
   
        
    
