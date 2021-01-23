    private List<DataTable> ReadDataTables(string fileName)
    {
        List<DataTable> tables = new List<DataTable>();
        DataTable currentTable = null;
    
        using (StreamReader reader = new StreamReader(fileName))
        {   
            while (!reader.EndOfStream)
            {                    
                var currentLine = reader.ReadLine(); // get the next line from the file
                if (String.IsNullOrWhiteSpace(currentLine)) continue; // ignore blank rows
    
                // skip rows marking end of table, reset the current table
                if (currentLine.StartsWith("@EndTable", StringComparison.OrdinalIgnoreCase))
                {
                    currentTable = null;
                    continue;
                }
    
                // initialize a new table
                if (currentLine.StartsWith("@Table", StringComparison.OrdinalIgnoreCase))
                {
                    currentTable = new DataTable();
                    tables.Add(currentTable); 
    
                    // initialise the columns
                    var columns = reader.ReadLine().Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                    foreach (var column in columns)
                        currentTable.Columns.Add(column, typeof(String));
    
                    continue;
                }
    
                if (currentTable == null) continue; // file is not in the format we were expecting
                        
                // add data row
                var dataRow = currentTable.NewRow();
                dataRow.ItemArray = currentLine.Split(new char[] { ';' });
                currentTable.Rows.Add(dataRow);
            }
        }
    
        return tables;
    }
