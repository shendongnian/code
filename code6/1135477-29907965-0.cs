    try
    {
        string[] seps = { "\",", ",", ",\"" };
        string[] quotes = { "\"" };
        foreach (var line in File.ReadLines(csvFilePath))
        {
            var fields = line.Split(seps).Select(s => s.Trim(quotes)).ToArray();
             
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
                    if (fieldData[i] == "")
                    {
                        fields[i] = null;
                    }
                }
                csvData.Rows.Add(fields); 
            }
        }
    }
