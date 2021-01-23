    string txt = File.ReadAllText("medicalreports.txt");
    //Separate records
    string[] separator = { "===================END OF RESULT===================" };
    string[] arrRecords = txt.Split(separator, StringSplitOptions.RemoveEmptyEntries);
    DataTable table = new DataTable();
    // Loop through records
    for (int i = 0; i < arrRecords.Length; i++)
    {
        string[] lines = arrRecords[i].Split('\n');
        DataRow row = new DataRow();
        // Loop through fields
        for (int j = 0; j < lines.Length; j++)
        {
            string[] keyValue = lines[j].Split(':');
            string field = keyValue[0].Trim();
            string value = keyValue[1].Trim();
            // Since not all records contain all columns, make sure this column exists. If not add it.
            if (!table.Columns.Contains(field))
            {
                table.Columns.Add(field);
            }
            row[field] = value;
        }
        table.Rows.Add(row);
    }
