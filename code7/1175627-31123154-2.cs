    /// <summary>
    /// Creates a comma separated value string from a datatable.
    /// </summary>
    public static string ToCSV(DataTable table) 
    {
        StringBuilder csv = new StringBuilder();
        for(int i = 0; i < table.Columns.Count ;i++) // process the column headers
        {
            if (i > 0)
                csv.Append(",");
            csv.Append(_FormatToCSVField(table.Columns[i].ColumnName));
        }
        if (table.Columns.Count > 0)
            csv.Append("\r\n");
        for (int i = 0; i < table.Rows.Count; i++) // process the row data
        {
            for (int j = 0; j < table.Columns.Count; j++) // process each field in the data row.
            {
                if (j > 0) 
                    csv.Append(",");
                csv.Append(_FormatToCSVField(table.Rows[i][j].ToString()));
            }
            csv.Append("\r\n");
        }
        return csv.ToString();
    }
    private static string _FormatToCSVField(string unformattedField)
    {
        return "\"" + unformattedField.Replace("\"", "\"\"") + "\"";
    }
