    for (int i = 0; i <= rdr.Count; i++)
    {
        string value = rdr[i];
        if(value == "1")
        {
             listOfColumns.Add(value);
        }
    }
    foreach (string listItem in listOfColumns)
        comboBox1.Items.Add(listItem);
