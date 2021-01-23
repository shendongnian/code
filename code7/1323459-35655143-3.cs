    var columnNames = String.Join(",", sortedDT.Columns
      .OfType<DataColumn>()
      .Select(column => column.ColumnName));
    
    var data = sortedDT.Rows
      .OfType<DataRow>() 
      .Select(row => String.Join(",", row.ItemArray));
    
    var source = new String[] {columnNames}
      .Concat(data);
    
    File.WriteAllLines(CSVpath, source);
