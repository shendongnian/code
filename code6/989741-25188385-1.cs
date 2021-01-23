    SqlDataReader dataReader = command.ExecuteReader();
    while (dataReader.Read())
    {
        string[] row = new string[dataReader.FieldCount];
        for (int i = 0; i < dataReader.FieldCount; i++)
        {
            row[i] = dataReader.GetValue(i).ToString();
        }
        items.Add(row);
    }
