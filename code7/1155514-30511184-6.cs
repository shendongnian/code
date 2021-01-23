    // sql.CommandText can be replaced with the raw SQL Query String
    string query = sql.CommandText;
    string removeSelect = query.Substring(7); // Remove the SELECT and space
    string[] splitOnFrom = removeSelect.Split(new string[] { " FROM " }, StringSplitOptions.RemoveEmptyEntries);
    string[] columns = splitOnFrom[0].Split(','); // Get each Column
    string[] tables = splitOnFrom[1].Split(','); // Get each Table
