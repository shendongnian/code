    // create a target table with 2 columns
    DataTable destinationTable = new DataTable();
    destinationTable.Columns.Add("Col1");
    destinationTable.Columns.Add("Col2");
                
    // select all the rows from the first table, combined with the corresponding value for that row in the second table
    var rowsCombined = table1
        .AsEnumerable()
        .Select((row, rowNumber) => new object[] { row[0], table2.Rows[rowNumber][0] });
    
    foreach (var data in rowsCombined)
        destinationTable.LoadDataRow(data, true);       
