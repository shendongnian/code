    string rep = "replace_";  // base string for replace fields
    string fix = "ignore_";   // base string for ignore fields
    int idxErrors = 0;        // Current position in the error array
    int idxReplace = 0;       // Current position in the replace array
    int fixCounter = 1;
    int repCounter = 1;
    string entry = "";
    for (int i = 0; i < columnNames.Length; i++)
    {
        // Is this the index of a column that should be ignored?
        if (idxErrors < error.Length && i == error[idxErrors])
        {
            entry = fix + fixCounter.ToString("D2");
            idxErrors++;
            fixCounter++;
        }
        // Is this the index of a column that should have a different name??
        else if (idxReplace < replace.Length && i == replace[idxReplace])
        {
            entry = rep + repCounter.ToString("D2");
            idxReplace++;
            repCounter++;
        }
        else
            entry = columnNames[i];
            
        // Now create the column
        DataColumn oDataColumn = new DataColumn(entry, typeof(string));
        oDataColumn.DefaultValue = string.Empty;
        oDataTable.Columns.Add(oDataColumn);
    }
