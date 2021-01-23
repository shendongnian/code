    // sql.CommandText can be replaced with the raw SQL Query String
    string query = sql.CommandText;
    string removeSelect = query.Substring(7); // Remove the SELECT and space
    string removeAfterFrom = removeSelect.Substring(0, removeSelect.IndexOf("FROM")); // Remove the FROM
    string[] columns = removeAfterFrom.Split(','); // Get each Column
    
    List<string> tableNames = new List<string>();
    for (int i = 0; i < columns.Length; i++)
    {
        string[] columnName = columns[i].Split('.');
        if (columnName.Length > 1)
            if (!tableNames.Contains(columnName[0]))
                tableNames.Add(columnName[0]).Trim();
    }
