    while (reader.Read())
    {
       for (int i = 0; i < reader.FieldCount; i++)
       {
           Console.WriteLine("\t{0}", reader[i]);
       }
    }
