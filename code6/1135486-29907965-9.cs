    DataTable csvData = new DataTable();
    string csvFilePath = @"C:\Users\" + csvFileName + ".csv";
    try
    {
        string[] seps = { "\",", ",\"" };
        char[] quotes = { '\"', ' ' };
        string[] colFields = null;
        foreach (var line in File.ReadLines(csvFilePath))
        {
            var fields = line
                .Split(seps, StringSplitOptions.None)
                .Select(s => s.Trim(quotes).Replace("\\\"", "\""))
                .ToArray();
             
            if (colFields == null)
            {
                colFields = fields;
                foreach (string column in colFields)
                {
                    DataColumn datacolumn = new DataColumn(column);
                    datacolumn.AllowDBNull = true;
                    csvData.Columns.Add(datacolumn);
                }
            }
            else
            {
                for (int i = 0; i < fields.Length; i++)
                {
                    if (fields[i] == "")
                    {
                        fields[i] = null;
                    }
                }
                csvData.Rows.Add(fields); 
            }
        }
    }
