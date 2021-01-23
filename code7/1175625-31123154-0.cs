        /// <summary>
    /// Returns DataTable from CSV string.  All Column data types are set to string.
    /// </summary>
    public static DataTable ToDataTable(string CSV) 
    {
        DataTable table = new DataTable();
        bool foundColumnHeader = false;
        string[] rows = CSV.Split("\r\n".ToCharArray());
        string[] fields;
        string row = "", value = "";
        for (int i = 0; i < rows.Length; i++) 
        {
            row = rows[i];
            if(row.Trim().Length == 0)  continue;
            // remove closing delimiters and split to values
            row = row.Remove(row.Length - 1, 1);
            fields = row.Replace("\",", "|").Split('|');
          
            for (int j = 0; j < fields.Length; j++)
            {
                value = fields[j].Remove(0, 1);// remove opening delimiters
                value = value.Replace("\"\"", "\""); // un-escape existing parentheses
                fields[j] = value;
            }
            if (foundColumnHeader) // processing a data row
                table.Rows.Add(fields);
            else // processing the header row 
            {
                foundColumnHeader = true;
                for (int j = 0; j < fields.Length; j++)
                    table.Columns.Add(fields[j], typeof(string)); // all values processed as strings
            }
        }
        return table;
    }
