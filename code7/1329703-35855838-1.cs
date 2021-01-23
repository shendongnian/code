    string MY_DEFAULT_VALUE = 'Pick One:';
    string queryString = "SELECT * FROM my_table";
    //Populate Dictionary:
    Dictionary<string,ComboBox > columnDictionary= new Dictionary<string, ComboBox>();
    columnDictionary.Add("COL_A", comboBox1);
    columnDictionary.Add("COL_B", comboBox2);
    columnDictionary.Add("COL_C", comboBox3);
    //etc...
    List<KeyValuePair<string, ComboBox>> appendedColumns = new List<KeyValuePair<string, ComboBox>>();
    foreach (KeyValuePair<string, ComboBox> entry in columnDictionary)
    {
        if (!String.Equals(entry.Value.Text, MY_DEFAULT_VALUE, StringComparison.OrdinalIgnoreCase))
        {
            string currentColumnName = entry.Key;
            string currentColumnParameter = "@" + entry.Key;
            if (appendedColumns.Count>1)
            {
                queryString += " AND ";
            }
            else
            {
                queryString += " WHERE ";
            }
            queryString += currentColumnName + " = " + currentColumnParameter;
            appendedColumns.Add(entry);
        }
    }
    cmd.CommandText = queryString;
    if (appendedColumns.Count > 0)
    {        
        foreach (KeyValuePair<string, ComboBox> entry in appendedColumns)
        {
            string currentColumnParameter = "@" + entry.Key;
            string currentParameterValue = entry.Value.Text;
            cmd.Parameters.AddWithValue(currentColumnParameter, currentParameterValue);
        }
    }
    //Continue on your way...
