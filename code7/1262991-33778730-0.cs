    while (reader.Read())
    
    {
        row = new DataRow();
        row.ItemArray = new object[reader.FieldCount];
        reader.GetValues(row.ItemArray);
        foreach (object item in row.ItemArray)
        {
            streamWriter.Write((string)item + "\t");
        }
        streamWriter.WriteLine();
    
    }
