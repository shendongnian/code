    while (reader.Read())
    {
       // Skip row if columns are null
       if (reader.IsDBNull(reader.GetOrdinal("PHAddress4"))) continue;
       if (reader.IsDBNull(reader.GetOrdinal("PHAddress5"))) continue;
    
       // No nulls, go ahead and read the columns
        Console.WriteLine(reader["PHAddress4"].ToString());
        Console.WriteLine(reader["PHAddress5"].ToString());
      ...
